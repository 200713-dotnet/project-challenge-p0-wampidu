using System;
using System.Collections.Generic;
using PizzaStore.Domain.Models;

namespace PizzaStore.Client
{
  public class Startup
  {
    public Order CreateOrder(User user, Store store)
    {
      try
      {
        var order = new Order();

        user.Orders.Add(order);
        store.Orders.Add(order);

        return order;
      }
      catch
      {
        throw new System.Exception("we messed up");
        //return null;
      }
      finally
      {
        GC.Collect();
      }
    }
    internal static void InitialMenu()
    {
      System.Console.WriteLine("Select 1 for Cheese Pizza");
      System.Console.WriteLine("Select 2 for Pepperoni Pizza");
      System.Console.WriteLine("Select 3 for Hawaiian Pizza");
      System.Console.WriteLine("Select 4 for Custom Pizza");
      System.Console.WriteLine("Select 5 to display cart");
      System.Console.WriteLine("Select 6 to remove a pizza from the cart");
      System.Console.WriteLine("Select 7 to place your order");
      System.Console.WriteLine("Select 8 to view your order");
      System.Console.WriteLine("Select 9 to exit");
      System.Console.WriteLine();
    }
    internal static void ToppingMenu()
    {
      System.Console.WriteLine("Please specify up to 5 toppings you would like (cheese included by default)");
      System.Console.WriteLine("Select 1 for pepperoni");
      System.Console.WriteLine("Select 2 for sausage");
      System.Console.WriteLine("Select 3 for mushroom");
      System.Console.WriteLine("Select 4 for bacon");
      System.Console.WriteLine("Select 5 for anchovies");
      System.Console.WriteLine("Select 6 for olives");
      System.Console.WriteLine("Select 7 for onion");
      System.Console.WriteLine("Select 8 for chicken");
      System.Console.WriteLine("Select 9 to finish selection");
    }
    internal static void SizeMenu()
    {
      System.Console.WriteLine("Select 1 for a small pizza: $5.00");
      System.Console.WriteLine("Select 2 for a medium pizza: $7.00");
      System.Console.WriteLine("Select 3 for a large pizza: $9.00");
    }
    internal static void CrustMenu()
    {
      System.Console.WriteLine("Select 1 for a regular crust");
      System.Console.WriteLine("Select 2 for a stuffed crust");
      System.Console.WriteLine("Select 3 for a flatbread");
      System.Console.WriteLine("Select 4 for a thin crust");
    }
  }
}