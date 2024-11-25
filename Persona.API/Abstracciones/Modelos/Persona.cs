using System.ComponentModel.DataAnnotations;
using static Abstracciones.Validaciones.ValidacionesPersona;

namespace Abstracciones.Modelos
{
    public class Persona
    {
        [Required(ErrorMessage = "El campo Identificacion es requerida")]
        [RegularExpression(@"^[1-9]-\d{4}-\d{4}$",ErrorMessage ="El formato de la identificaci[on debe 0-0000-0000")]
        public string? Identificacion { get; set; }
        [Required(ErrorMessage = "El campo Nombre es requerido")]
        [StringLength(20, ErrorMessage = "Que tamano debe ser entre 5 y 20 caracteres", MinimumLength = 5)]
        [RegularExpression(@"^[a-zA-Z]*$")]
        public string? Nombre { get; set; }
        [Required(ErrorMessage = "El campo Apellido es requerido")]
        [StringLength(20, ErrorMessage = "Que tamano debe ser entre 5 y 20 caracteres", MinimumLength = 5)]
        [RegularExpression(@"^[a-zA-Z]*$")]
        [ValidacionMayusculas]
        public string? Apellido { get; set; }
    }



    public class PersonaBD: Persona
    {
        public Guid Id { get; set; }
    }
}
