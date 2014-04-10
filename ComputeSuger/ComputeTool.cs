using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ComputeSuger
{
    public class ComputeTool
    {
        public bool judgeDigital(string target)
        {
            string pattern = @"^\d+\.?\d+$|^\d+$";
            if (!Regex.IsMatch(target, pattern))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
