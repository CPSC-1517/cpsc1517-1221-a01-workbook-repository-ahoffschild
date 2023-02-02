using NHLSystemClassLibrary;
using System.Linq.Expressions;
using System.Text.Json;

namespace NHLConsoleApp
{
    internal class Program
    {

        static void Main(string[] args)
        {
            //TODO 1: Create a new CSV file with 5 player objects
            // 2: Create a new Team instance
            // 3: Write the code to read from the CSV file, using the PlayerTryParse method and add the player to the team instance
            // 4: Display the team info and all players in the team
            static void ReadPlayerDataFromCsv(ref Team newTeam, string filePath)
            {
                /*
                 * string[] allLines = File.ReadAllLines(filePath);
                 * foreach (string line in allLines)
                 * {
                 *      readinglogichere
                 * }
                 */
                using (StreamReader sr = new StreamReader(filePath))
                {
                    try
                    {
                        string csvLine = sr.ReadLine();
                        List<Player> playerList = new List<Player>();
                        Player currentPlayer = new Player();
                        while (csvLine != null)
                        {
                            Player.TryParse(csvLine, ref currentPlayer);
                            playerList.Add(currentPlayer);
                            csvLine = sr.ReadLine();
                        }
                        foreach (Player player in playerList)
                        {
                            newTeam.AddPlayer(player);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error reading from file with exception {ex.Message}");
                    }
                }
            }

            static void DemoLinqMethods()
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
            }

            static void WriteTeamInfoToJsonFile(Team currentTeam, string jsonFilePath)
            {
                try
                {
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        WriteIndented = true,
                        IncludeFields = true,
                    };
                    string jsonString = JsonSerializer.Serialize<Team>(currentTeam, options);
                    File.WriteAllText(jsonFilePath, jsonString);
                    Console.WriteLine("Write to JSON file was successful.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error serializing to JSON file with exception: {ex.Message}");
                }
            }

            static Team ReadTeamFromJsonFile(string jsonFilePath)
            {
                Team currentTeam = null;
                try
                {
                    string jsonString = File.ReadAllText(jsonFilePath);
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        WriteIndented = true,
                        IncludeFields = true,
                    };
                    currentTeam = JsonSerializer.Deserialize<Team>(jsonString);
                    currentTeam.AddPlayer(JsonSerializer.Deserialize<Player>(jsonString));

				}
                catch (Exception ex)
                {
                    Console.WriteLine($"Error deserializing from JSON file with exception: {ex.Message}");
                }
                return currentTeam;
            }

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

            Team notCanucks = new Team("Not Canucks", "Vancouver", "Rogers Arena", Conference.Western, Division.Pacific);
            string filePath = ("C:\\Users\\ahoffschild1\\Documents\\GitHub\\cpsc1517-1221-a01-workbook-repository-ahoffschild\\NHLSolution\\notCanucks.csv");
			string filePath2 = ("C:\\Users\\ahoffschild1\\Documents\\GitHub\\cpsc1517-1221-a01-workbook-repository-ahoffschild\\NHLSolution\\notCanucks.json");
            //ReadPlayerDataFromCsv(ref notCanucks, filePath);
            notCanucks = ReadTeamFromJsonFile(filePath2);
            Console.WriteLine($"{notCanucks.City} {notCanucks.Name} plays in {notCanucks.Arena} with players:");
            foreach (Player player in notCanucks.Players)
            {
                Console.WriteLine(player.ToString());
            }
            //WriteTeamInfoToJsonFile(notCanucks, filePath2);
        }
    }
}