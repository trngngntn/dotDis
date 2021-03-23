using System;
namespace Utils
{
    public static class ConsoleLogger
    {
        public static void Log(string str, params object[] args)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("[LOG] " + str,args);
            Console.ResetColor();
            Console.WriteLine("");
        }
        public static void Warn(string str, params object[] args)
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.Write("[WARN] " + str,args);
            Console.ResetColor();
            Console.WriteLine("");
        }
        public static void Error(string str, params object[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Red;
            Console.Write("[ERROR] " + str,args);
            Console.ResetColor();
            Console.WriteLine("");
        }
    }
}