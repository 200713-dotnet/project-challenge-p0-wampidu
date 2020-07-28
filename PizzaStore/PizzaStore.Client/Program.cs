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

      List<Pizza> cart4 = new List<Pizza>();
      var startup = new PizzaStore.Client.Startup();
      var user = new User();
      var store = new Store();
      var order = startup.CreateOrder(user, store);

      
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
        Startup.InitialMenu();
        int sizesel;
        int crustsel;
        int select;
        int.TryParse(Console.ReadLine(), out select);

        switch (select)
        {
          case 1:
            string Size = "";
            string Crust = "";
            cart.CreatePizza("L", "Stuffed", new List<string> { "cheese" });
            System.Console.WriteLine("added Cheese Pizza");
            break;
          case 2:
            cart.CreatePizza("L", "Stuffed", new List<string> { "pepperoni", "cheese" });
            System.Console.WriteLine("added Pepperoni Pizza");
            break;
          case 3:
            cart.CreatePizza("L", "Stuffed", new List<string> { "hawaiian", "cheese" });
            System.Console.WriteLine("added Hawaiian Pizza");
            break;
          case 4:
            Startup.SizeMenu();
            int.TryParse(Console.ReadLine(), out sizesel);
            //string topping1 = "";
            //string topping2 = "";
            List<string> CustomPizzaToppings = new List<string>();
            CustomPizzaToppings.Add("cheese");
            Size = "";
            switch(sizesel)
            {
              case 1:
                Size = "small";
                break;
              case 2:
                Size = "medium";
                break;
              case 3:
                Size = "large";
                break;
            }
            //^^Size Selection
            
            Crust = "";
            Startup.CrustMenu();
            int.TryParse(Console.ReadLine(), out crustsel);
            switch(crustsel)
            {
              case 1:
                Crust = "regular crust";
                break;
              case 2:
                Crust = "stuffed crust";
                break;
              case 3:
                Crust = "flatbread crust";
                break;
              case 4:
                Crust = "thin crust";
                break;
            }
            //^^Crust Selection
            int TotalToppings = 0;
            var end = false;
            System.Console.WriteLine();
            do
            {
              int toppingsel;
              
              Startup.ToppingMenu();
              int.TryParse(Console.ReadLine(), out toppingsel);
              switch(toppingsel)
              {
                case 1:
                  CustomPizzaToppings.Add("pepperoni");
                  TotalToppings = 1 + TotalToppings;
                  break;
                case 2:
                  CustomPizzaToppings.Add("sausage");
                  TotalToppings = 1 + TotalToppings;
                  break;
                case 3:
                  CustomPizzaToppings.Add("mushroom");
                  TotalToppings = 1 + TotalToppings;
                  break;
                case 4:
                  CustomPizzaToppings.Add("bacon");
                  TotalToppings = 1 + TotalToppings;
                  break;
                case 5:
                  CustomPizzaToppings.Add("anchovies");
                  TotalToppings = 1 + TotalToppings;
                  break;
                case 6:
                  CustomPizzaToppings.Add("olives");
                  TotalToppings = 1 + TotalToppings;
                  break;
                case 7:
                  CustomPizzaToppings.Add("onion");
                  TotalToppings = 1 + TotalToppings;
                  break;
                case 8:
                  CustomPizzaToppings.Add("chicken");
                  TotalToppings = 1 + TotalToppings;
                  break;
                case 9:
                  if (TotalToppings >= 1)
                  {
                    end = true;
                  }
                  else
                  {
                    System.Console.WriteLine("Please select at least one topping, otherwise choose the cheese pizza preset");
                  }
                  break;
              }
            } while (TotalToppings < 3 || end == true);
            //^^Topping Selection
            cart.CreatePizza(Size, Crust, CustomPizzaToppings);
            System.Console.WriteLine($"added {Size} {Crust} custom pizza");
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

