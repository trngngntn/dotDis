using System;

namespace Extensions
{
    public static class StringExtensions
    {
        public static int ToInt(this string s)
        {
            return Int32.Parse(s);
        }
    }
}