using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NHLWebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        //Define an auto-implemented property for username
        [BindProperty]
        public string Username { get; set; }
        [BindProperty]
        public int? Age { get; set; }
        [BindProperty]
        public string? DmitStream { get; set; }
        [BindProperty]
        public string? Gender { get; set; }
        //Define auto-implemented property for displaying our feedback messages
        public string? InfoMessage { get; private set; }

        public void OnPost()
        {
            // Generate a lucky number between 1 and 50 (inclusive)
            // and send a feedback message with format:
            // "Hello {username}. Your lucky number is {luckyNumber}."
            var rand = new Random();
            var randomNumber = rand.Next(1, 51);
            InfoMessage = $"Hello {Username}. Your lucky number is {randomNumber}. Your age is {Age}, and you are in the {DmitStream} NAIT Stream. Gender is {Gender},";
        }

        public void OnGet()
        {

        }
    }
}