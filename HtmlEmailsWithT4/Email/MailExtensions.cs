namespace HtmlEmailsWithT4.Email
{
    using System.Net.Mail;
    using System.Text;

    public static class MailExtensions
    {
        public static void CreateHtmlBody(this MailMessage message, string body)
        {
            var mailTemplate = new EmailTemplate { Body = body };
            var html = AlternateView.CreateAlternateViewFromString(mailTemplate.TransformText(), Encoding.UTF8, "text/html");
            message.AlternateViews.Add(html);
        }

        public static void CreateHtmlBody(this MailMessage message, object template)
        {
            var mailTemplate = new EmailTemplate { BodyTemplate = template };
            var html = AlternateView.CreateAlternateViewFromString(mailTemplate.TransformText(), Encoding.UTF8, "text/html");
            message.AlternateViews.Add(html);
        }
    }
}
