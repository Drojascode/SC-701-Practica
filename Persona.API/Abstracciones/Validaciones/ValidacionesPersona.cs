using Abstracciones.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Validaciones
{
    internal class ValidacionesPersona
    {
        public class ValidacionMayusculas : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                Persona persona = (Persona)validationContext.ObjectInstance;
                if (persona.Apellido.ToUpper() != persona.Apellido)
                    return new ValidationResult("El campo debe estar en mayusculas");
                return ValidationResult.Success;
            }
        }
    }
}
