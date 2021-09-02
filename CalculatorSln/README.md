# Calculus User Manual
Upon application launch, user will see the following console interface:

![Calculus Empty Image](https://i.imgur.com/bIgOyGz.jpg)

Calculus has 2 lines: one for input (the lower line) and one to display expression.
The cursor starts at the input line:

![Calculus First Value](https://i.imgur.com/XNMRdaf.jpg)

Once you input an operation char (+, -, * or /), value of the first number and 
operation type will be displayed at the top line:

![Calculus Expression](https://i.imgur.com/bjtitI2.jpg)

Then, user needs to input the second number and either hit ENTER or another
operation to get the result:

![Calculus Result](https://i.imgur.com/6hj1RZ4.jpg)

* Features:
  - Operation chaining
  - Reset on C
  - Two lines to keep track of operations
  
# Architecture Description
Calculus consists of 4 simple classes:
- Header.cs

Contains ASCII art and instruction strings. Display() method to visualize the graphics.
- InputLine.cs

Contains methods that manage swapping between input and expression lines and clearing them.
- InputManager.cs

Defines a key method which is responsible for input logic via Console.ReadKey(). Validation is omitted in this project due to input restrictions applied by GetInput() method.
- CalculatorLogic

Application's calculator logic is defined here.
