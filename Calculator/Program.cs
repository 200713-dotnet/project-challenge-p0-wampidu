using System;

namespace Calculator
{
  class Program
  {
    static void Main()
    {
      Console.WriteLine("Welcome to your Basic Calculator");
      var stay = true;
      do
      {
        Console.WriteLine("Menu");
        Console.WriteLine("Press 1 for Addition");
        Console.WriteLine("Press 2 for Subtraction");
        Console.WriteLine("Press 3 for Multiplication");
        Console.WriteLine("Press 4 for Division");
        Console.WriteLine("Press 5 to exit the program");
        var choice = Console.ReadLine();
        switch (choice)
        {
          case "1":
            //var input1 = (double)Console.ReadLine();   //explicit casting, with exception
            //var input2 = Console.ReadLine() as double; //explicit casting, will not return error but will return 'null'
            var input1 = double.Parse(Console.ReadLine());//explicit parsing with 0
            double input2;
            double.TryParse(Console.ReadLine(), out input2);//explicit parsing with exception ---> returns boolean 
            Add(input1, input2);
            break;
          case "2":
            /*var input3 = double.Parse(Console.ReadLine());      >
            var input4 = double.Parse(Console.ReadLine());        >    My Code
            double difference = input3 - input4;                  >
            Console.WriteLine($"The answer is {difference}");     >
            break;*/
            double input3;
            double input4;

            if (double.TryParse(Console.ReadLine(), out input3))
            {
              Console.WriteLine("valid");
            }
            else
            {
              Console.WriteLine("not valid");
            }

            if (double.TryParse(Console.ReadLine(), out input4))
            {
              Console.WriteLine("valid");
            }
            else
            {
              Console.WriteLine("not valid");
            }
            Subtract(input3, input4);
            break;
          case "5":
            stay = false;
            break;
        }
      } while (stay);
    }
    static void Add(double operand1, double operand2)
    {

      var result = operand1 + operand2;
      Console.WriteLine($"Your answer is: {result}");
    }
    static void Subtract(double operand1, double operand2)
    {
      var result = operand1 - operand2;
      Console.WriteLine($"Your answer is: {result}");
    }
  }
}
