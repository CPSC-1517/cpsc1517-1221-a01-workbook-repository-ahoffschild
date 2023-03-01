using Microsoft.AspNetCore.Mvc.RazorPages;
using NHLSystemClassLibrary;

namespace NHLWebApp.Pages
{
    public class csvPlayersPageModel : PageModel
    {
        public List<Player> playerList = new List<Player>();
        const string filePath = "C:\\Users\\ahoffschild1\\Documents\\GitHub\\cpsc1517-1221-a01-workbook-repository-ahoffschild\\NHLSolution\\NHLWebApp\\wwwroot\\data\\notCanucks.csv";

        public void OnGet()
        {
            string currentLine;
            Player newPlayer;
            using (StreamReader sr = new StreamReader(filePath))
            {
                while ((currentLine = sr.ReadLine()) != null)
                {
                    newPlayer = Player.Parse(currentLine);
                    playerList.Add(newPlayer);
                }
            }
        }
    }
}
