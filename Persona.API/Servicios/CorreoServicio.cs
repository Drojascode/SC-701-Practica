using Abstracciones.Interfaces.Reglas;
using Abstracciones.Interfaces.Servicios;
using Abstracciones.Modelos;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Servicios
{
    public class CorreoServicio : ICorreoServicio
    {
        private IConfiguration _configuracion;


        public CorreoServicio(IConfiguration configuracion)
        {
            _configuracion = configuracion;
        }

        public async Task Enviar(Correo correo)
        {
            var clienteSmtp = GenerarCliente();
            var mensaje = new MailMessage(_configuracion["Correo:Usuario"], correo.Destinatario, correo.Asunto, correo.Cuerpo);
            mensaje.IsBodyHtml = true;
            if (correo.Adjuntos != null && correo.Adjuntos.Any())
                foreach (var adjunto in correo.Adjuntos)
                {
                    mensaje.Attachments.Add(new Attachment(new System.IO.MemoryStream(adjunto.Contenido), adjunto.Nombre));
                }

            try
            {
                clienteSmtp.Send(mensaje);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                mensaje.Dispose();
                clienteSmtp.Dispose();
            }
        }


        private SmtpClient GenerarCliente()
        {
            var cliente = new SmtpClient(_configuracion["Correo:Servidor"], int.Parse(_configuracion["Correo:Puerto"]))
            {
                Credentials = new System.Net.NetworkCredential(_configuracion["Correo:Usuario"], _configuracion["Correo:Password"]),
                EnableSsl = bool.Parse(_configuracion["Correo:SSL"])
            };
            return cliente;
        }
    }
}
