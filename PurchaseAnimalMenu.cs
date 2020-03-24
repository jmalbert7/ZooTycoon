using System;

namespace ZooTycoon
{
    public class PurchaseAnimalMenu : IMenu
    {
        public string Name { get; private set; }

        public PurchaseAnimalMenu()
        {
            Name = "Purchase an Animal";
        }

        public void DisplayName()
        {
            Console.Clear();
            Console.WriteLine(Name);
        }
        public void DisplayOptions()
        {
            Console.WriteLine("1. Buy a Tiger {0:C}", Tiger.GetPurchaseCost());
            Console.WriteLine("2. Buy a Penguin");
            Console.WriteLine("3. Buy a Turtle");
            Console.WriteLine("4. Nevermind");
        }

        public int GetUserSelection()
        {
            DisplayName();
            ValidateStringToInt selection = new ValidateStringToInt("");
            bool isValid;
            do
            {
                DisplayOptions();
                selection.StringInput = Console.ReadLine();
                selection.ValidateUserSelection();
                isValid = (selection.IsValid && ValidateMenuOption(selection.IntOutput - 1));
                if (isValid == false)
                    Console.WriteLine("Sorry, that is not an option.");
            } while (isValid == false);

            return selection.IntOutput;
        }
        public bool ValidateMenuOption(int input)
        {
            if (Enum.IsDefined(typeof(PurchaseAnimalOptions), input))
                return true;
            else
                return false;
        }
    }
}
