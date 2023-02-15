using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesDemo.Pages
{
    public class RollDiceModel : PageModel
    {
        public void OnGet()
        {
            DiceFaceValueImg = "img/icons/000000/transparent/1x1/delapouite/rolling-dices.png";
        }

        public int DiceFaceValue { get; private set; }
        public string DiceFaceValueImg { get; private set; }
        public string[] DiceImages =
        {
            "img/icons/000000/transparent/1x1/delapouite/dice-six-faces-one.png",
            "img/icons/000000/transparent/1x1/delapouite/dice-six-faces-two.png",
            "img/icons/000000/transparent/1x1/delapouite/dice-six-faces-three.png",
            "img/icons/000000/transparent/1x1/delapouite/dice-six-faces-four.png",
            "img/icons/000000/transparent/1x1/delapouite/dice-six-faces-five.png",
            "img/icons/000000/transparent/1x1/delapouite/dice-six-faces-six.png"
        };

        public void OnPost()
        {
            var rand = new Random();
            DiceFaceValue = rand.Next(1, 7);
            DiceFaceValueImg = DiceImages[DiceFaceValue - 1];
        }
    }
}
