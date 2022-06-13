using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSUnitLabb1
{
    public class Password
    {
        // Method from Customer2 class
        public static bool ChangePassword(string Password)
        {
            if (!Password.Any(char.IsLetter) || !Password.Any(char.IsNumber))
            {
                return false;
            }
            else if (Password.Length < 8)
            {
                return false;
            }
            return true;
        }
    }
}
