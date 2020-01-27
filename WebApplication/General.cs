using Dominio.EntidadesDto;
using RazorEngine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Web;

public static class General
{
    public static HttpResponseBase getResonseBadRequest(HttpResponseBase Response, HttpStatusCode request)
    {
        Response.Clear();
        Response.TrySkipIisCustomErrors = true;

        Response.StatusCode = (int)request;
        return Response;
    }

    public static string ObtenerHtmlplantillas(string nombretemplate, object Model)
    {
        var Path = AppDomain.CurrentDomain.BaseDirectory;

        var Pathtemplate = string.Format("{0}Views\\Plantillas\\{1}.cshtml", Path, nombretemplate);
        var template = File.ReadAllText(Pathtemplate);

        template = Razor.Parse(template, Model);
        return template;

    }

    public static bool SendEmail(EmailDto edto)
    {

        SmtpClient client = null;
        try
        {
            try
            {
                client = new SmtpClient("smtp.dgi.gob.ni");
                client.UseDefaultCredentials = false;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Port = 25;
                System.Net.Mail.MailMessage correo = null;
                MailAddress de = new MailAddress("ksilva@dgi.gob.ni", "School Control");

                MailAddress para;


                para = new MailAddress(edto.Email, "Usuario School Control");

                string asunto = "Notificación de Cambio de Contraseña";

                correo = new System.Net.Mail.MailMessage(de, para);

                AlternateView htmlView = AlternateView.CreateAlternateViewFromString(
                                           edto.BodyEmail,
                                           System.Text.Encoding.UTF8,
                                           MediaTypeNames.Text.Html);

                correo.AlternateViews.Add(htmlView);

                correo.Subject = asunto;
                correo.Priority = System.Net.Mail.MailPriority.Normal;
                correo.IsBodyHtml = true;
                client.Send(correo);

                return true;
            }
            catch (Exception ex)
            {

                throw new Exception("Error en el envio de Email. ", ex);
            }
        }
        finally
        {
            if (client != null)
                client.Dispose();
        }

    }

}