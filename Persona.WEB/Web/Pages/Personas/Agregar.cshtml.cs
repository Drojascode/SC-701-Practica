using Abstracciones.Interfaces.Reglas;
using Abstracciones.Modelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages.Personas
{
    [Authorize(Roles = "1")]
    public class AgregarModel : PageModel
    {
        private IConfiguracion _configuracion;
        [BindProperty]
        public PersonaBD persona { get; set; } = default!;
        public AgregarModel(IConfiguracion configuracion)
        {
            _configuracion = configuracion;
        }
        public ActionResult OnGet()
        {
            return Page();
        }
        public async Task<ActionResult> OnPost()
        {
            if (!ModelState.IsValid)
                return Page();
            string endpoint = _configuracion.ObtenerMetodo("ApiEndPoints", "AgregarPersona");
            var cliente = new HttpClient();
            cliente.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", HttpContext.User.Claims.Where(c => c.Type == "Token").FirstOrDefault().Value);
            var respuesta = await cliente.PostAsJsonAsync(endpoint, persona);
            respuesta.EnsureSuccessStatusCode();
            return RedirectToPage("./Index");
        }
    }
}
