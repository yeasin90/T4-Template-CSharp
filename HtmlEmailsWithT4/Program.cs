namespace HtmlEmailsWithT4
{
    using System.Net.Mail;
    using Email;

    class Program
    {
        static void Main(string[] args)
        {
            var mail = new MailMessage
            {
                From = new MailAddress("me@mycompany.com", "Me AndMe"),
                Subject = "Me poking You",
                Body = string.Empty
            };

            mail.To.Add("someemail@somecompany.com");

            var template = new BodyTemplate
                               {
                                   FirstName = "You",
                                   LastName = "AndYou"
                               };

            mail.CreateHtmlBody(template);

            using (var client = new SmtpClient())
            {
                client.SendAsync(mail, null);
            }
        }
    }
}
