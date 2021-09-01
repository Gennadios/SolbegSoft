using System;

namespace Calculator
{
    class Program
    {
        static void Main()
        {
            Header.Display();
            while (true)
            {
                DisplayResult();
                GetFirstNumberAndDisplayExpressionStatus();
                GetSecondNumberAndDisplayFullExpression();
            }
        }

        // initial result is null by default
        private static void DisplayResult()
        {
            CalculatorLogic.CurrentOperation = null;
            InputLine.MoveCursorDownAndClearLine();
            Console.Write(CalculatorLogic.Result);
        }

        private static void GetFirstNumberAndDisplayExpressionStatus()
        {
            CalculatorLogic.Value1 = double.Parse(InputManager.GetInput());
            CalculatorLogic.ResetResult();
            InputLine.MoveCursorUpAndClearLine();
            InputLine.OperationString = $"{CalculatorLogic.Value1} {CalculatorLogic.CurrentOperation}";
            Console.Write(InputLine.OperationString);
            InputLine.MoveCursorDownAndClearLine();
        }

        private static void GetSecondNumberAndDisplayFullExpression()
        {
            CalculatorLogic.Value2 = double.Parse(InputManager.GetInput());
            CalculatorLogic.ExecuteOperation();
            InputLine.MoveCursorUpAndClearLine();
            InputLine.OperationString = $"{CalculatorLogic.Value1} {CalculatorLogic.CurrentOperation} {CalculatorLogic.Value2} = ";
            Console.Write(InputLine.OperationString);
        }
    }
}
