namespace MvcCalculator.Models
{
    public class Calculator
    {
        public static double? Value1 { get; set; }
        public static double? Value2 { get; set; }
        public double? Result { get; set; }
        public static string Operation { get; set; }

        public void Solve(string operation)
        {
            ManageClear(operation);

            AssignValues();
            if (Value1 != null && Value2 != null)
            {
                switch (Operation)
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
                        break;
                }
                ResetValues();
            }
        }

        public double? DisplayResult() => Result == null ? 0 : Result;

        private void ManageClear(string operation)
        {
            if (operation == "c")
                FullReset();
            else
                Operation ??= operation;
        }

        private void AssignValues()
        {
            if (Value1 == null)
            {
                Value1 = Result;
                Result = 0;
                return;
            }
            if (Value2 == null)
                Value2 = Result;
        }

        private void ResetValues() 
        {
            Value1 = null;
            Value2 = null;
            Operation = null;
        }

        private void FullReset()
        {
            Value1 = null;
            Value2 = null;
            Result = null;
            Operation = null;
        }
    }
}
