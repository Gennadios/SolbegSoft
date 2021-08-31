using System;

namespace Calculator
{
    static class CalculatorLogic
    {
        public static double? Value1 { get; set; }
        public static double? Value2 { get; set; }
        public static string CurrentOperation { get; set; }
        public static double? Result { get; private set; }

        internal static void ExecuteOperation()
        {
            switch (CurrentOperation)
            {
                case "+":
                    Result = Value1 + Value2;
                    break;
                case "-":
                    Result = Value1 - Value2;
                    break;
                case "*":
                    Result = Value1 * Value2;
                    break;
                case "/":
                    Result = Value1 / Value2;
                    break;
                default:
                    Console.Write("Something went wrong");
                    break;
            }
        }

        internal static void ResetResult() => Result = null;

        internal static void Clear()
        {
            Value1 = default;
            Value2 = default;
            CurrentOperation = default;
            Result = default;
        }
    }
}
