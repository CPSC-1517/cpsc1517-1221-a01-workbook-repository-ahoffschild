using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesDemo.Pages
{
    public class LottoQuickPicksModel : PageModel
    {
        [BindProperty]
        public string playerName { get; set; }
        [BindProperty]
        public LottoType lottoType { get; set; }
        [BindProperty]
        public int quickPickAmount { get; set; } = 3;

        public List<int[]> quickPicks { get; private set; } = new();

        public string? InfoMessage { get; private set; }
        public string? ErrorMessage { get; private set; }

        public void OnGet()
        {
        }

        public void OnPost()
        {

        }

        public void OnPostGenerate()
        {
            if (string.IsNullOrWhiteSpace(playerName))
            {
                ErrorMessage = "<strong>Username</strong> is required and cannot be blank.";
            }
            else
            {
                //Remove previous numbers
                quickPicks.Clear();
                Random gen = new Random();
                int[] temp;
                List<int> dupes = new List<int>();
                //Create new array
                for (int x = 0; x < quickPickAmount; x++)
                {
                    if (lottoType == LottoType.Lotto649)
                    {
                        temp = new int[6];
                        for (int j = 0; j < 6; j++)
                        {
                            temp[j] = gen.Next(1, 50);
                            while (dupes.Contains(temp[j]))
                            {
                                temp[j] = gen.Next(1, 50);
                            }
                            dupes.Add(temp[j]);
                        }
                    }
                    else
                    {
                        temp = new int[7];
                        for (int j = 0; j < 7; j++)
                        {
                            temp[j] = gen.Next(1, 50);
                            while (dupes.Contains(temp[j]))
                            {
                                temp[j] = gen.Next(1, 50);
                            }
                            dupes.Add(temp[j]);
                        }
                    }
                    Array.Sort(temp);
                    quickPicks.Add(temp);
                    dupes.Clear();
                }
                InfoMessage = $"Hello {playerName}. You are playing {lottoType}.";

            }
        }

        public void OnPostClear()
        {
            playerName = null;
            lottoType = LottoType.None;
            InfoMessage = null;
            ErrorMessage = null;
            //return RedirectToPage();
        }
    }

    public enum LottoType
    {
        Lotto649,
        LottoMax,
        None
    }
}
