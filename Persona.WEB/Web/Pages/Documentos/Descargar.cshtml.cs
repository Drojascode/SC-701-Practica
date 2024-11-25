using Abstracciones.Interfaces.Reglas;
using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;
using System.Text.Json;

namespace WebRazor.Pages.Documentos
{
    public class DescargarModel : PageModel
    {
        private IConfiguracion _configuracion;

        public DescargarModel(IConfiguracion configuracion)
        {
            _configuracion = configuracion;
        }
        [BindProperty]
        public DocumentoConContenido documento { get; set; } = default!;
        public async Task<ActionResult> OnGet(Guid? id)
        {
            if (id == null)
                return NotFound();

            string endPoint = _configuracion.ObtenerMetodo("ApiEndPoints", "ObtenerDocumento");
            var cliente = new HttpClient();
            var solicitud = new HttpRequestMessage(HttpMethod.Get, string.Format(endPoint, id));
            var respuesta = await cliente.SendAsync(solicitud);
            respuesta.EnsureSuccessStatusCode();
            if (respuesta.StatusCode == HttpStatusCode.OK)
            {
                var resultado = await respuesta.Content.ReadAsStringAsync();
                var opciones = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                documento = JsonSerializer.Deserialize<DocumentoConContenido>(resultado,opciones);
                return File(documento.Contenido, documento.Tipo, documento.Nombre);
            }
            return NotFound();
        }
            
    }
}
