using System.Collections.Generic;

namespace PizzaStore.Domain.Models
{
  public class Order
  {
    public List<Pizza> Pizzas { get; }
    public double ordercost;
    public int pizzanum;

    public void CreatePizza(string size, string crust, List<string> toppings)
    {
      Pizzas.Add(new Pizza(size, crust, toppings));
    }

    public Order()
    {
      Pizzas = new List<Pizza>();
      ordercost = 0;
      pizzanum = 0;
    }

  }

}