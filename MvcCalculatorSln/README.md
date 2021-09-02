# MVC Calculator User Manual
Upon application launch, user will see the following UI in your browser:

![Calculator UI](https://i.imgur.com/76vQcC4.jpg)

This is a standard one line calculator. User can either input values with keyboard while text box is selected or by clicking GUI buttons.

Input is restricted only to decimal numbers (of *double* data type). 

## How to use:

- Input a number value
- Select an operation (+, -, * or /)
- Input another number value
- Click on an operation or "="
- When result is highlighted, select another operation if you want to continue with calculations

**NOTE:** Operation chaining is not yet supported, make sure you click on operation once you see the result.
  
# Architecture Description
This Calculator is based on MVC design pattern. The whole application has one Model, one View and one Controller.
- Model (Calculator.cs)

Contains Solve() method which is responsible for calculations and logic.
- View (Index.cshtml)

Contains the calculator GUI mark-up. It's a tabled embedded into a form of type POST. On operations click, the form is submitted to server therefore updating the Model data. 
- Controller (HomeController.cs)

Defines two Index() methods. The main logic is initiated within the POST version of Index(). 
