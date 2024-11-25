using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Abstracciones.Interfaces.Reglas;
using System.Net;
using Abstracciones.Modelos;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;

namespace Web.Pages.Personas
{
    [Authorize(Roles ="1,2")]
    public class IndexModel : PageModel
    {
        private IConfiguracion _configuracion;
        public IList<PersonaBD> personas { get; set; }=default!;
        public IndexModel(IConfiguracion configuracion)
        {
            _configuracion = configuracion;
        }

        public async Task OnGet()
        {
            string endpoint = _configuracion.ObtenerMetodo("ApiEndPoints", "ObtenerPersonas");
            var cliente= new HttpClient();
            var solicitud= new HttpRequestMessage(HttpMethod.Get,endpoint);
            cliente.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", HttpContext.User.Claims.Where(c => c.Type == "Token").FirstOrDefault().Value);
            var respuesta = await cliente.SendAsync(solicitud);
            respuesta.EnsureSuccessStatusCode();
            if (respuesta.StatusCode == HttpStatusCode.OK)
            {
                var resultado=await respuesta.Content.ReadAsStringAsync();
                var opciones=new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                personas = JsonSerializer.Deserialize<List<PersonaBD>>(resultado, opciones);
            }
        }
    }
}
