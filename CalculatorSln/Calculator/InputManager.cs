using System;
using System.Linq;

namespace Calculator
{
    static class InputManager
    {
        private static ConsoleKeyInfo _readKeyResult;
        private static string _output;
        private static int _currentIndex;
        private static char[] _allowedChars = 
            new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', ','};

        internal static string GetInput()
        {
            _output = CalculatorLogic.Result.ToString();
            _currentIndex = _output.Length;
            do
            {
                _readKeyResult = Console.ReadKey(true);

                if(_allowedChars.Contains(_readKeyResult.KeyChar) && _output.Length < Header.Width)
                    AppendOutput();
                else
                {
                    // handle operation (+, -, *, / chars)
                    if (!string.IsNullOrEmpty(_output) && InputIsOperation())
                    {
                        CalculatorLogic.CurrentOperation ??= _readKeyResult.KeyChar.ToString();
                        return _output;
                    }
                    else if(_readKeyResult.Key == ConsoleKey.C)
                    {
                        CalculatorLogic.Clear();
                        InputLine.ClearLines();
                        _output = string.Empty;
                    }
                    else if (_readKeyResult.Key == ConsoleKey.Enter && CalculatorLogic.CurrentOperation != null)
                        return _output;
                    else if (_readKeyResult.Key == ConsoleKey.Backspace)
                        RemoveLastChar();
                }
            } while (true);
        }

        private static void AppendOutput()
        {
            _output += _readKeyResult.KeyChar;
            Console.Write(_readKeyResult.KeyChar);
            _currentIndex++;
        }

        private static void RemoveLastChar()
        {
            if (_currentIndex > 0)
            {
                _output = _output.Remove(_output.Length - 1);
                Console.Write(_readKeyResult.KeyChar);
                Console.Write(' ');
                Console.Write(_readKeyResult.KeyChar);
                _currentIndex--;
            }
        }

        internal static bool InputIsOperation()
        {
            return _readKeyResult.Key == ConsoleKey.Add ||
                   _readKeyResult.Key == ConsoleKey.Subtract ||
                   _readKeyResult.Key == ConsoleKey.Multiply ||
                   _readKeyResult.Key == ConsoleKey.Divide;
        }
    }
}
