using System;
namespace Utils
{
    public static class ConsoleLogger
    {
        public static void Log(string str, params object[] args)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\t[LOG] " + str,args);
            Console.ResetColor();
        }
        public static void Error(string str, params object[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("\t[LOG] " + str,args);
            Console.ResetColor();
        }
    }
}