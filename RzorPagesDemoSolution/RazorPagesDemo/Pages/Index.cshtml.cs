using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesDemo.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public DateTime CurrentDateTime { get; private set; } = DateTime.Now;

        public int LuckyNumber { get; private set; } = 15;

        public void OnGet()
        {
            var rnd = new Random();
            {
                LuckyNumber = rnd.Next(1, 51);
            }
        }
    }
}