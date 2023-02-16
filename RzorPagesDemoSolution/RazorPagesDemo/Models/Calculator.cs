namespace RazorPagesDemo.Models
{
    public class Calculator
    {
        public int num1 { get; set; }
        public int num2 { get; set; }

        public int Add() => num1 + num2;
        public int Subtract() => num1 - num2;
        public int Multiply() => num1 * num2;
        public int Divide() => num1 / num2;
    }
}
