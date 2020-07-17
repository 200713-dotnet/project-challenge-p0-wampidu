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
    internal static void PrintMenu()
    {
        System.Console.WriteLine("Select 1 for Cheese Pizza");
        System.Console.WriteLine("Select 2 for Pepperoni Pizza");
        System.Console.WriteLine("Select 3 for Hawaiian Pizza");
        System.Console.WriteLine("Select 4 for Custom Pizza");
        System.Console.WriteLine("Select 5 to display cart");
        System.Console.WriteLine("Select 6 to exit");
        System.Console.WriteLine();
    }
  }
}