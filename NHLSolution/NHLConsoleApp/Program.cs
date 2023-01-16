using NHLSystemClassLibrary;

namespace NHLConsoleApp
{
    internal class Program
    {

        static void Main(string[] args)
        {
            //Console.WriteLine("Enter the team name: ");
            //string teamName = Console.ReadLine();

            try
            {
                Team oilers = new Team("Oilers", "Edmonton", "Rogers Place", Conference.Western, Division.Pacific);
                Console.WriteLine($"{oilers.Name}, {oilers.City}, {oilers.Arena}");
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch
            {
                Console.WriteLine("Incorrect exception thrown.");
            }
        }
    }
}