using System;
using System.Collections.Generic;
using PizzaStore.Domain.Models;
using PizzaStore.Storing.Repositories;

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
      Console.WriteLine("Welcome to the pizza ordering service");
      System.Console.WriteLine();
      System.Console.WriteLine();
      List<Pizza> cart4 = new List<Pizza>();
      var startup = new PizzaStore.Client.Startup();
      var user = new User();
      var store = new Store();
      var order = startup.CreateOrder(user, store);
      try
      {
        Menu2(startup.CreateOrder(user, store), store);
      }
      catch (Exception ex)
      {
        System.Console.WriteLine(ex.Message);
      }

    }

    static void DisplayCart(Order cart)
    {
      double total = 0;
      int pizzacount = 0;
      foreach (var pizza in cart.Pizzas)
      {
        pizzacount = 1 + pizzacount;
        System.Console.WriteLine($"{pizzacount}: Price: ${pizza.Price()}.00 {pizza}");
        //System.Console.WriteLine(pizza.Price());
        total = total + pizza.Price();
      }
      System.Console.WriteLine($"Your cart total is ${total}.00");
      System.Console.WriteLine();
    }

    static void Menu2(Order cart, Store store)
    {
      var exit = false;
      var pr = new PizzaRepository();
      do
      {
        Startup.InitialMenu();
        int sizesel;
        int crustsel;
        int select;
        int.TryParse(Console.ReadLine(), out select);
        switch (select)
        {
          case 1:
            string size = "";
            string crust = "";
            Startup.SizeMenu();
            int.TryParse(Console.ReadLine(), out sizesel);
            switch (sizesel)
            {
              case 1:
                size = "small";
                break;
              case 2:
                size = "medium";
                break;
              case 3:
                size = "large";
                break;
            }
            crust = "regular";
            var pizza = cart.CreatePizza(size, crust, new List<string> { "cheese" }, "cheese pizza");
            System.Console.WriteLine($"added a {size} Cheese Pizza");
            System.Console.WriteLine();
            //pr.Create(pizza);
            break;
          case 2:
            size = "";
            Startup.SizeMenu();
            int.TryParse(Console.ReadLine(), out sizesel);
            switch (sizesel)
            {
              case 1:
                size = "small";
                break;
              case 2:
                size = "medium";
                break;
              case 3:
                size = "large";
                break;
            }
            crust = "regular";
            pizza = cart.CreatePizza(size, crust, new List<string> { "pepperoni", "cheese" }, "pepperoni pizza");
            System.Console.WriteLine($"added a {size} Pepperoni Pizza");
            System.Console.WriteLine();
            break;
          case 3:
            size = "";
            Startup.SizeMenu();
            int.TryParse(Console.ReadLine(), out sizesel);
            switch (sizesel)
            {
              case 1:
                size = "small";
                break;
              case 2:
                size = "medium";
                break;
              case 3:
                size = "large";
                break;
            }
            crust = "regular";
            pizza = cart.CreatePizza(size, crust, new List<string> { "hawaiian", "cheese" }, "hawaiian");
            System.Console.WriteLine($"added a {size} Hawaiian Pizza");
            System.Console.WriteLine();
            break;
          case 4:
            Startup.SizeMenu();
            int.TryParse(Console.ReadLine(), out sizesel);
            //string topping1 = "";
            //string topping2 = "";
            List<string> CustomPizzaToppings = new List<string>();
            CustomPizzaToppings.Add("cheese");
            size = "";
            switch (sizesel)
            {
              case 1:
                size = "small";
                break;
              case 2:
                size = "medium";
                break;
              case 3:
                size = "large";
                break;
            }
            //^^Size Selection
            crust = "";
            Startup.CrustMenu();
            int.TryParse(Console.ReadLine(), out crustsel);
            switch (crustsel)
            {
              case 1:
                crust = "regular";
                break;
              case 2:
                crust = "stuffed";
                break;
              case 3:
                crust = "flatbread";
                break;
              case 4:
                crust = "thin";
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
              switch (toppingsel)
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
                  if (TotalToppings >= 2)
                  {
                    end = true;
                  }
                  else
                  {
                    System.Console.WriteLine("Please select at least two toppings, otherwise choose from the preset options");
                  }
                  break;
              }
            } while (TotalToppings < 5 && end == false);
            //^^Topping Selection
            pizza = cart.CreatePizza(size, crust, CustomPizzaToppings, "custom pizza");
            System.Console.WriteLine($"added a {size} {crust} custom pizza");
            System.Console.WriteLine();
            break;
          case 5:
            if (cart.pizzanum == 0)
            {
              System.Console.WriteLine("No pizzas are in your cart.");
              System.Console.WriteLine();
            }
            else DisplayCart(cart);
            break;
          case 6:
            int OrderNum = cart.Pizzas.Count;
            if (OrderNum > 0)
            {
              System.Console.WriteLine("select a pizza to remove");
              System.Console.WriteLine("press enter to cancel");
              DisplayCart(cart);
              int delete;
              int.TryParse(Console.ReadLine(), out delete);
              if (delete <= OrderNum && delete > 0)
              {
                cart.RemovePizza(delete);
                System.Console.WriteLine("Pizza removed");
                System.Console.WriteLine();
              }
              else
              {
                System.Console.WriteLine("deletion canceled");
              }
            }
            else
            {
              System.Console.WriteLine("no pizza to delete");
            }
            break;
          case 7:
            OrderNum = cart.Pizzas.Count;
            if(OrderNum > 0)
            {
            var fm = new FileManager();
            fm.Write(cart);
            System.Console.WriteLine("Order successfully placed.");
            }
            else System.Console.WriteLine("No pizzas in your cart. Order cannot be placed.");;
            //System.Console.WriteLine("Thank you goodbye");
            
            break;
          case 8:
            var fmr = new FileManager();
            DisplayCart(fmr.Read());
            //exit = true;
            break;
          case 9:
            exit = true;
            break;
        }
      } while (!exit);
    }
  }
}

