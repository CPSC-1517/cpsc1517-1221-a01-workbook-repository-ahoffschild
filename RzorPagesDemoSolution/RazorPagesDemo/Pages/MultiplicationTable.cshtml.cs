using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesDemo.Pages
{
    public enum TableType
    {
        Multiplication,
        Addition,
        Subtraction
    }

    public class MultiplicationTableModel : PageModel
    {
        [BindProperty]
        public int DigitsVertically { get; set; }
        [BindProperty]
        public int DigitsHorizontally { get; set;}
        public TableType? TableTypeToGenerate { get; private set; }
        public void OnGet()
        {
        }
    }
}
