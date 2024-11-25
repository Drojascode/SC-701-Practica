using Abstracciones.Interfaces.Reglas;
using Abstracciones.Modelos;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.StaticFiles;
using System.Net;
using System.Text.Json;

namespace WebRazor.Pages.Documentos
{
    public class CargarModel : PageModel
    {
        private IConfiguracion _configuracion;
        private IWebHostEnvironment _environment;

        public CargarModel(IConfiguracion configuracion, IWebHostEnvironment environment)
        {
            _configuracion = configuracion;
            _environment = environment;
        }
        [BindProperty]
        public IFormFile archivo { get; set; }
        [BindProperty]
        public Correo correo { get; set; }
        [BindProperty]
        public HttpStatusCode envioEstado { get; set; } 
        public async Task<ActionResult> OnGet()
        {
            return Page();
        }
        public async Task<ActionResult> OnPost()
        {
            if (!ModelState.IsValid)
                return Page();
            var resultado= await CargarDocumento();
            envioEstado = resultado.StatusCode;                      
            return Page();
        }

        private async Task<HttpResponseMessage> CargarDocumento()
        {
            var file = Path.Combine(_environment.WebRootPath, "Documentos", archivo.FileName);
            using (var fileStream = new FileStream(file, FileMode.Create))
            {
                await archivo.CopyToAsync(fileStream);
            }
            byte[] contenido = System.IO.File.ReadAllBytes(file);
            System.IO.File.Delete(file);
            DocumentoContenido documento = new DocumentoContenido() { Nombre = archivo.FileName, Contenido = contenido };
            string endPoint = _configuracion.ObtenerMetodo("ApiEndPoints", "AgregarDocumento");
            var cliente = new HttpClient();
            var respuestaDocumentos = await cliente.PostAsJsonAsync<DocumentoContenido>(endPoint, documento);           
            correo.Adjuntos = new List<DocumentoContenido> { documento };
            var respuestaEnvio = await EnviarCorreo();
            return respuestaEnvio;
        }
        private async Task<HttpResponseMessage> EnviarCorreo()
        {
            string endPoint = _configuracion.ObtenerMetodo("ApiEndPoints", "EnviarCorreo");
            var cliente = new HttpClient();
            var respuesta = await cliente.PostAsJsonAsync<Correo>(endPoint, correo);
            return respuesta;
        }
    }
}
