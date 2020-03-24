using System;

namespace ZooTycoon
{
    
    public class ValidateStringToInt : IUserSelectionValidation
    {
        public string StringInput { get; set; }
        public bool IsValid { get; private set; }
        public int IntOutput { get; private set; }

        public ValidateStringToInt(string str)
        {
            StringInput = str;
            IsValid = false;
            IntOutput = -1;
        }
        public void ValidateUserSelection()
        {
            if (int.TryParse(StringInput, out int selectionInt))
            {
                IsValid = true;
                IntOutput = selectionInt;
            }
            else
                IsValid = false;
        }

    }
}
