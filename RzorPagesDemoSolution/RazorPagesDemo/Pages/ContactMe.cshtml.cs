using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Mail;

namespace RazorPagesDemo.Pages
{
    public class ContactMeModel : PageModel
    {
        private string _contactName;
        private string _contactEmail;
        private string _contactComments;
        [BindProperty]
        public string ContactName
        {
            get { return _contactName; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    ErrorMessage = ("Name is required.");
                }
                _contactName = value;
            }
        }
        [BindProperty]
        public string ContactEmail
        {
            get { return _contactEmail; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    ErrorMessage = ("Email is required.");
                }
                _contactEmail = value;
            }
        }
        [BindProperty]
        public string ContactComments
        {
            get { return _contactComments; }
            set
            {
                if (value == null || value.Length < 10)
                {
                    ErrorMessage = ("Comments must have at least 10 characters.");
                }
                _contactComments = value;
            }
        }
        [BindProperty]
        public bool ContactSubscribe { get; set; }
        public string InfoMessage { get; set; }
        public string ErrorMessage { get; set; } = "";

        public void OnGet()
        {
        }

        public void OnPostSendMessage()
        {
            if (string.IsNullOrEmpty(ErrorMessage))
            {
                string subscribeMessage = (ContactSubscribe) ? "Yes" : "No";
                InfoMessage = $"Name: {ContactName}<br />Email: {ContactEmail}<br />Comments: {ContactComments}<br />Subscribed: {subscribeMessage}";
            }
            else
            {
                InfoMessage = null;
            }
        }
        public IActionResult OnPostClear()
        {
            ContactName = null;
            ContactEmail = null;
            ContactComments = null;
            ContactSubscribe = false;
            return RedirectToPage();
        }
        public void OnPostReset()
        {

        }

        private void EmailFunction()
        {
            SmtpClient sendMailClient = new();
            sendMailClient.Host = Configuration["MailServerSettings:Host"];
            sendMailClient.Port = int.Parse(Configruation["MailServerSettings:Port"]);
            sendMailClient.EnableSsl = bool.Parse(Configuration["MailServerSettings:EnableSsl"])

            NetworkCredential
        }
    }
}
