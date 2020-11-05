using BE;
using System;
using System.Net;
using System.Net.Mail;

namespace BLL
{
    public class EmailService
    {
        public Boolean send(Usuario usuario, bool updatePass)
        {
            try
            {
                String FROM = "mimailfalso2020@gmail.com";
                String FROMNAME = "Cuentas ProEasy";
                String TO = usuario.Email;
                String SMTP_USERNAME = "mimailfalso2020@gmail.com";
                String SMTP_PASSWORD = "Pepe147258*";
                String CONFIGSET = "ConfigSet";
                String HOST = "smtp.gmail.com";
                String SUBJECT = "Bienvenido a ProEasy";
                String BODY;
                if (!updatePass)
                    BODY = "<h1>Bienvenido a ProEasy</h1><p> Usuario: " + usuario.Username + "</p><p> Contraseña: " + usuario.Contrasenia + "</p>";
                else
                    BODY = "<h1>Reseteo de contraseña</h1><p> Contraseña: " + usuario.Contrasenia + "</p>";
                int PORT = 587;

                MailMessage message = new MailMessage();
                message.IsBodyHtml = true;
                message.From = new MailAddress(FROM, FROMNAME);
                message.To.Add(new MailAddress(TO));
                message.Subject = SUBJECT;
                message.Body = BODY;
                message.Headers.Add("X-SES-CONFIGURATION-SET", CONFIGSET);

                using (var client = new SmtpClient(HOST, PORT))
                {
                    client.Credentials = new NetworkCredential(SMTP_USERNAME, SMTP_PASSWORD);
                    client.EnableSsl = true;
                    try
                    {
                        Console.WriteLine("Attempting to send email...");
                        client.Send(message);
                        Console.WriteLine("Email sent!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("The email was not sent.");
                        Console.WriteLine("Error message: " + ex.Message);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return true;
        }
    }
}