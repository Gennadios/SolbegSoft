using System;

namespace Calculator
{
    static class InputLine
    {
        public static string OperationString { get; set; }

        internal static void MoveCursorUpAndClearLine()
        {
            (_, int top) = Console.GetCursorPosition();
            Console.SetCursorPosition(0, top - 1);
            ClearLine();
        }

        internal static void MoveCursorDownAndClearLine()
        {
            (_, int top) = Console.GetCursorPosition();
            Console.SetCursorPosition(0, top + 1);
            ClearLine();
        }

        internal static void ClearLine()
        {
            Console.Write(new string(' ', Header.Width));
            (_, int top) = Console.GetCursorPosition();
            Console.SetCursorPosition(0, top);
        }

        internal static void ClearLines()
        {
            (_, int top) = Console.GetCursorPosition();
            Console.SetCursorPosition(0, top - 1);
            Console.WriteLine(new string(' ', Header.Width));
            Console.WriteLine(new string(' ', Header.Width));
            Console.SetCursorPosition(0, top);
        }
    }
}
