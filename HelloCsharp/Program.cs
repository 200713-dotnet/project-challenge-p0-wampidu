using System;

namespace HelloCsharp
{
  class Program
  {
    static void Main()
    {
      Console.Write("Enter first name: ");
      var first = Console.ReadLine(); // var is a lazy datatype; its determined by data given
      Console.Write("Enter last name: ");
      string last = Console.ReadLine(); // string is an eager datatype; determined explicitly

      Console.WriteLine("{0} {1}", first, last); //{0} refers to a placeholder that can then be defined after
      Console.WriteLine($"{first} {last}"); //another way to do the command above

      

      Console.ReadLine();
    }
  }
}