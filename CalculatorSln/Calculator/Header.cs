using System;

namespace Calculator
{
    static class Header
    {
        private static ConsoleColor _titleColor = ConsoleColor.Cyan;
        private static ConsoleColor _instructionsColor = ConsoleColor.DarkCyan;

        const string Title = @"
   ______      __           __          
  / ____/___ _/ /______  __/ /_  _______
 / /   / __ `/ / ___/ / / / / / / / ___/
/ /___/ /_/ / / /__/ /_/ / / /_/ (__  ) 
\____/\__,_/_/\___/\__,_/_/\__,_/____/                                      
";

        const string Instructions =
            "  <0 - 9> and <,> keys - input numbers\n" +
            "  <ENTER> - confirm entry, <C> - Clear\n" +
            "  <+, -, *, /> - available operations";

        // this is the literal width of title, will be used to limit input length
        internal const int Width = 40;

        internal static void Display()
        {
            Console.ForegroundColor = _titleColor;
            Console.WriteLine(Title);
            Console.ForegroundColor = _instructionsColor;
            Console.WriteLine(Instructions);
            Console.ForegroundColor = _titleColor;
            Console.WriteLine(new string('-', Width));
            Console.ResetColor();
        }
    }
}
