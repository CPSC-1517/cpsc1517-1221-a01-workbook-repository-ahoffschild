using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NHLSystemClassLibrary;
using System.Text.Json;

namespace NHLWebApp.Pages
{
    public class jsonTeamPageModel : PageModel
    {
        public Team displayTeam;
        //List<Player> players = new List<Player>();
        const string filePath = "C:\\Users\\ahoffschild1\\Documents\\GitHub\\cpsc1517-1221-a01-workbook-repository-ahoffschild\\NHLSolution\\NHLWebApp\\wwwroot\\data\\notCanucks.json";

        public void OnGet()
        {
            displayTeam = ReadTeamFromJsonFile(filePath);
        }

        static Team ReadTeamFromJsonFile(string jsonFilePath)
        {
            Team currentTeam = null;
            try
            {
                string jsonString = System.IO.File.ReadAllText(jsonFilePath);
                JsonSerializerOptions options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    IncludeFields = true,
                };
                currentTeam = JsonSerializer.Deserialize<Team>(jsonString, options);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deserializing from JSON file with exception: {ex.Message}");
            }
            return currentTeam;
        }
    }
}
