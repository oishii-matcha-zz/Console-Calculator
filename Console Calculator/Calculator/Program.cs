using System;


    class Calculator
    {
        public static double DoOperation(double num1, double num2, string op)
        {
            double result = double.NaN; //Default value is "not-a-number" which we use if an operation, such as division, could result in an error.

            // Use a switch statement to do the math.
            switch (op)
            {
                case "+":
                    result = num1 + num2;
                    break;
                case "-":
                    result = num1 - num2;
                    break;
                case "*":
                    result = num1 * num2;
                    break;
                case "/":
                    //Ask the user to enter a non-zero divisor.
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                    }
                    break;
                // Return text for an incorrect option entry.
                default:
                    break;
            }
            return result;
        }
    }

class Program
{
    static void Main(string[] args)
    {
        bool endApp = false;
        //Display title as the C# consoloe calculator app.
        Console.WriteLine("Console Calculator in C#");
        Console.WriteLine("------------------------");

        while (!endApp)
        {
            //Declare variable and set to empty.
            string numInput1 = "";
            string numInput2 = "";
            double result = 0;

            //Ask the user to type the first number.
            Console.Write("Type a number, and then press Enter: ");
            numInput1 = Console.ReadLine();

            double cleanNum1 = 0;
            while (!double.TryParse(numInput1, out cleanNum1))
            {
                Console.Write("This is not a valid input. Please enter an integer value: ");
                numInput1 = Console.ReadLine();
            }

            //Ask the user to type the second number.
            Console.Write("Type another number, and then press Enter: ");
            numInput2 = Console.ReadLine();

            double cleanNum2 = 0;
            while (!double.TryParse(numInput2, out cleanNum2))
            {
                Console.Write("This is not a valid input. Please enter an integer value: ");
                numInput2 = Console.ReadLine();
            }

            //Ask the user to choose an operator.
            Console.WriteLine("Choose an operator from the following list:");
            Console.WriteLine("+: Add");
            Console.WriteLine("-: Subtract");
            Console.WriteLine("*: Multiply");
            Console.WriteLine("/: Divide");
            Console.Write("What is your choice? ");

            string op = Console.ReadLine();

            try
            {
                result = Calculator.DoOperation(cleanNum1, cleanNum2, op);
                if (double.IsNaN(result))
                {
                    Console.WriteLine("This operation will result in a mathematical error.");
                }
                else Console.WriteLine("Your result: {0:0.##}", result);
            }
            catch (Exception e)
            {
                Console.WriteLine("Oh no! An exception occured trying to do the math. - Details: " + e.Message);
            }

            Console.WriteLine("------------------------");

            //Wait for the user to respond before closing.
            Console.WriteLine("Press 'n' and Enter to close the app, or press any other key and Enter to continue: ");
            if (Console.ReadLine() == "n") endApp = true;

            Console.WriteLine("n");
        }
        return;
    }
}