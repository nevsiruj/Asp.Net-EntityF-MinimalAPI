using MailKit.Net.Smtp;
using MimeKit;
using MailKit;
using WebAPI.Entities;
using MailKit.Security;

namespace WebAPI.Services
{
    public class EmailService
    {
        

        public void SendMail(ContactoCliente cc)
        {
            // Send Email To Email User Register//           
            string Servidor = "smtp.hostinger.com";
            int Puerto = 465;
            String EmailUser = "no-reply@sys-ux.com";
            String EmailPass = "f6i@Gf5yR093MhAYj%Fk";


            MimeMessage mensaje = new();
            mensaje.From.Add(new MailboxAddress("Welcome Dear!", EmailUser));
            mensaje.To.Add(new MailboxAddress("Destino", cc.Email));
            mensaje.Subject = "Hola desde C# con MailKit";

            BodyBuilder CuerpoMensaje = new();
            CuerpoMensaje.TextBody = "Hola";
            CuerpoMensaje.HtmlBody = "Hola, <b> Bienvenido al Mundo de Disney </b>";

            mensaje.Body = CuerpoMensaje.ToMessageBody();

            SmtpClient ClienteSmtp = new();
            ClienteSmtp.CheckCertificateRevocation = false;
            //ClienteSmtp.Connect(Servidor, Puerto, MailKit.Security.SecureSocketOptions.StartTls);
            ClienteSmtp.Connect(Servidor, Puerto, true);

            ClienteSmtp.Authenticate(EmailUser, EmailPass);
            ClienteSmtp.Send(mensaje);
            ClienteSmtp.Disconnect(true);

            ///////
        }
    }
}
