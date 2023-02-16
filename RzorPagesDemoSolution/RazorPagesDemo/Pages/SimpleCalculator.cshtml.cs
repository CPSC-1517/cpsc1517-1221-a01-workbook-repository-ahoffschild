using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesDemo.Models;

namespace RazorPagesDemo.Pages
{
    public class SimpleCalculatorModel : PageModel
    {
        public string ?InfoMessage{ get; set; }
		[BindProperty]
        public Calculator Calculator { get; set; }

        public void OnGet()
        {
			Calculator = new Calculator();
        }

        public void OnPostAdd()
        {
			InfoMessage = $"{Calculator.num1} + {Calculator.num2} = {Calculator.Add()}";
        }
		public void OnPostSubtract()
		{
			InfoMessage = $"{Calculator.num1} - {Calculator.num2} = {Calculator.Subtract()}";
		}
		public void OnPostMultiply()
		{
			InfoMessage = $"{Calculator.num1} x {Calculator.num2} = {Calculator.Multiply()}";
		}
		public void OnPostDivide()
		{
			if (Calculator.num2 == 0)
			{
				throw new Exception("Cannot divide by zero.");
			}
			InfoMessage = $"{Calculator.num1} / {Calculator.num2} = {Calculator.Divide()}";
		}
	}
}
