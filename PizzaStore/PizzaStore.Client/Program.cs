﻿using System;
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
      Menu(cart4);


    }


    static void Menu(List<Pizza> cart)
    {
      var exit = false;
      var number = 0;
      var startup = new PizzaStore.Client.Startup();
      do
      {
        //if (number < cart.Length)
        //{
        System.Console.WriteLine("Select 1 for Cheese Pizza");
        System.Console.WriteLine("Select 2 for Pepperoni Pizza");
        System.Console.WriteLine("Select 3 for Hawaiian Pizza");
        System.Console.WriteLine("Select 4 for Custom Pizza");
        System.Console.WriteLine("Select 5 to display cart");
        System.Console.WriteLine("Select 6 to exit");
        System.Console.WriteLine();

        int select;
        int.TryParse(Console.ReadLine(), out select);

        switch (select)
        {
          case 1:
            var p = startup.CreatePizza("L", "Stuffed", new List<string> { "cheese" });
            cart.Add(p);
            number += 1;
            System.Console.WriteLine("added Cheese Pizza");
            break;
          case 2:
            number += 1;
            cart.Add(startup.CreatePizza("L", "Stuffed", new List<string> { "pepperoni" }));
            System.Console.WriteLine("added Pepperoni Pizza");
            break;
          case 3:
            number += 1;
            cart.Add(startup.CreatePizza("L", "Stuffed", new List<string> { "hawaiian" }));
            System.Console.WriteLine("added Hawaiian Pizza");
            break;
          case 4:
            number += 1;
            cart.Add(startup.CreatePizza("L", "Stuffed", new List<string> { "custom" }));
            System.Console.WriteLine("added Custom Pizza");
            break;
          case 5:
            DisplayCart(cart);
            break;
          case 6:
            System.Console.WriteLine("Thank you goodbye");
            exit = true;
            break;
        }
        //}
        //else
        // {
        //   DisplayCart(cart);
        //   exit = true;
        // }
      } while (!exit);
    }

    static void DisplayCart(List<Pizza> cart)
    {
      foreach (var pizza in cart)
      {
        System.Console.WriteLine(pizza);
      }

    }


  }
}

