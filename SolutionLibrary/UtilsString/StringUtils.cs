using System;

namespace UtilsLibraries
{
    public static class StringUtils
    {
        public static bool IsFirstCharUpper(this string str)
        {
            if (String.IsNullOrEmpty(str) || String.IsNullOrWhiteSpace(str))
            {
                return false;
            }

            return Char.IsUpper(str[0]);
        }
    }
}
