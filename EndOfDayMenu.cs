using System;

namespace ZooTycoon
{
    public class EndOfDayMenu : IMenu
    {
        public string  Name { get; set; }
        public EndOfDayMenu()
        {
            Name = "End of Day";
        }
        public void DisplayName()
        {
            Console.Clear();
            Console.WriteLine(Name);
        }
        public void DisplayOptions()
        {
            Console.WriteLine("1. View Zoo Summary");
            Console.WriteLine("2. Purchase an Adult Animal");
            Console.WriteLine("3. View Bank");
            Console.WriteLine("4. View Daily Summary");
            Console.WriteLine("5. Return");
        }
        public int GetUserSelection(IPlayer player)
        {
            DisplayName();
            Console.WriteLine("Today's Profit: {0:C}",player.GetProfit());
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
            if (Enum.IsDefined(typeof(EndOfDay), input))
                return true;
            else
                return false;
        }

    }
}
