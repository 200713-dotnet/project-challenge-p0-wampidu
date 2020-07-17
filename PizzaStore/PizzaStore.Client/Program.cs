using System;
using System.Collections.Generic;
using PizzaStore.Domain.Models;

namespace PizzaStore.Client
{
  class Program
  {
    static void Main()
    {
      Welcome();
    }


    static void Welcome()
    {
      Console.WriteLine("Welcome to PizzaWorld!");
      System.Console.WriteLine("Best Pizza in the World!");
      System.Console.WriteLine();

      /*
        arrays
      */
      //string[] cart1 = {"","",""};//1 dimensional array, this one is initialized values set
      string[] cart2 = new string[3];//array is not initialized this way unless keyword 'new' is used, uses default values
      //string[] cart3 = new[]{"","",""};//initial values - used for earlier C# versions or custom datatypes

      //list
      List<Pizza> cart4 = new List<Pizza>(); //default values
      //List<string> cart5 = new List<string>{""};//initial values
      //Menu(cart4);
      var startup = new PizzaStore.Client.Startup();
      var user = new User();
      var store = new Store();
      var order = startup.CreateOrder(user, store);

      /*  if(order != null)
       {
         Menu2(order);
       }
       else
       {
         System.Console.WriteLine("technical difficulties");
       } */
      try
      {
        Menu2(startup.CreateOrder(user, store));
      }
      catch (Exception ex)
      {
        System.Console.WriteLine(ex.Message);
      }

    }

    static void DisplayCart(Order cart)
    {
      foreach (var pizza in cart.Pizzas)
      {
        System.Console.WriteLine(pizza);
      }

    }

    static void Menu2(Order cart)
    {
      var exit = false;
      do
      {
        //if (number < cart.Length)
        //{
        Startup.PrintMenu();

        int select;
        int.TryParse(Console.ReadLine(), out select);

        switch (select)
        {
          case 1:
            cart.CreatePizza("L", "Stuffed", new List<string> { "cheese" });
            System.Console.WriteLine("added Cheese Pizza");
            break;
          case 2:
            cart.CreatePizza("L", "Stuffed", new List<string> { "pepperoni" });
            System.Console.WriteLine("added Pepperoni Pizza");
            break;
          case 3:
            cart.CreatePizza("L", "Stuffed", new List<string> { "hawaiian" });
            System.Console.WriteLine("added Hawaiian Pizza");
            break;
          case 4:
            cart.CreatePizza("L", "Stuffed", new List<string> { "custom" });
            System.Console.WriteLine("added Custom Pizza");
            break;
          case 5:
            DisplayCart(cart);
            break;
          case 6:
            var fm = new FileManager();
            fm.Write(cart);
            System.Console.WriteLine("Thank you goodbye");
            exit = true;
            break;
          case 7:
            var fmr = new FileManager();
            DisplayCart(fmr.Read());
            break;

        }
      } while (!exit);
    }

  }
}

