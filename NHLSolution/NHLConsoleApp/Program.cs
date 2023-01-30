using NHLSystemClassLibrary;
using System.Linq.Expressions;

namespace NHLConsoleApp
{
    internal class Program
    {

        static void Main(string[] args)
        {
            // Create a new array of the names of 12 of your favorite game titles
            string[] gameList = new string[] 
            { 
                "Metroid Prime 2: Echoes",
                "Psychonauts 2",
                "Halo 2",
                "Mega Man X",
                "Mega Man Zero 3",
                "30XX",
                "Slay the Spire",
                "Barotrauma",
                "Custom Robo: Battle Revolution",
                "Ace Combat 7: Skies Unknown",
                "Guilty Gear: Strive",
                "XCOM 2"
            };

            Console.WriteLine("ForEach:");
            foreach (string i in gameList)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("\nFor:");
            for (int i = 0; i < gameList.Length; i++)
            {
                Console.WriteLine(gameList[i]);
            }
            Console.WriteLine("\nEnnumerable ForEach");
            gameList.ToList().ForEach(i => Console.WriteLine(i));

            Console.WriteLine("\nSorted List");
            List<string> gameList2 = gameList.ToList();
            gameList2.OrderBy(i => i).ToList().ForEach(i => Console.WriteLine(i));

            //6
            Console.WriteLine("\n2 Sequels Only");
            gameList2.Where(i => i.Contains("2")).ToList().ForEach(i => Console.WriteLine(i));

            //7
            Console.WriteLine("\nDo we have any Mario Games?");
            Console.WriteLine(gameList2.Any(i => i.Contains("Mario")));

            //8
            string queryGameTitle = gameList2.Where(i => i.Contains("Mega")).FirstOrDefault();
            Console.WriteLine("\nFirst Mega Man game on the list?");
            Console.WriteLine(queryGameTitle);

            //Console.WriteLine("Enter the team name: ");
            //string teamName = Console.ReadLine();

            //try
            //{
            //    Team oilers = new Team("Oilers", "Edmonton", "Rogers Place", Conference.Western, Division.Pacific);
            //    Console.WriteLine($"{oilers.Name}, {oilers.City}, {oilers.Arena}");
            //}
            //catch (ArgumentNullException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            //catch
            //{
            //    Console.WriteLine("Incorrect exception thrown.");
            //}
        }
    }
}