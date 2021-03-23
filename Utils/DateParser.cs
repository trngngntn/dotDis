using System;
using System.Globalization;

namespace Utils{
    public static class DateParser
    {
        private static CultureInfo provider = CultureInfo.InvariantCulture;
        public static DateTime Parse(string value)
        {
            return DateTime.ParseExact(value,"dd/MM/yyyy HH:mm:ss", provider);
        }

    }
}