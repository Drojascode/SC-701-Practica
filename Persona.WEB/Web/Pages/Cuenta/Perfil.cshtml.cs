using Abstracciones.Interfaces.Reglas;
using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;
using System.Security.Claims;
using System.Text.Json;

namespace Web.Pages.Cuenta
{
    public class PerfilModel : PageModel
    {
        private IConfiguracion _configuracion;
        [BindProperty]
        public PerfilPersona perfil { get; set; } = default!;
        [BindProperty]
        public IFormFile archivo { get; set; }
        [BindProperty]
        public Correo correo { get; set; }
        [BindProperty]
        public HttpStatusCode envioEstado { get; set; }
        public PerfilModel(IConfiguracion configuracion)
        {
            _configuracion = configuracion;
        }
        public async Task OnGetAsync()
        {
            string endpoint = _configuracion.ObtenerMetodo("ApiEndPoints", "ObtenerPerfil");
            var cliente = new HttpClient();
            var IdUsuario = HttpContext.User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value;
            cliente.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", HttpContext.User.Claims.Where(c => c.Type == "Token").FirstOrDefault().Value);
            var solicitud = new HttpRequestMessage(HttpMethod.Get, string.Format(endpoint, IdUsuario));
            var respuesta = await cliente.SendAsync(solicitud);           
            if (respuesta.StatusCode == HttpStatusCode.OK)
            {
                var resultado = await respuesta.Content.ReadAsStringAsync();
                var opciones = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                perfil = JsonSerializer.Deserialize<PerfilPersona>(resultado, opciones);
            }
        }
    }
}