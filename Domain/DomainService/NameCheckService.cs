using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Domain
{
    public static class NameCheckService
    {
        public static bool IsTagNameValid(string tagName) 
        {
            string patternOne = "/^.{3,}$/";
            string patternTwo = "^[a - z] +$";
            Match matchOne = Regex.Match(tagName, patternOne, RegexOptions.None);
            Match matchTwo = Regex.Match(tagName, patternTwo, RegexOptions.None);

            if (matchOne.Success && matchTwo.Success)
                return true;

            return false;
        }

        public static string MakeUserTaskNameValid(string userTaskName)
        {
            if (userTaskName.Length == 0)
                throw new InvalidNameException("Name can not be empty");
            else if (userTaskName.Length == 1)
                return char.ToUpper(userTaskName[0]).ToString();
            else
                return char.ToUpper(userTaskName[0]) + userTaskName.Substring(1);
        }
    }
}
