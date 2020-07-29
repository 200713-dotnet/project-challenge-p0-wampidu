using System.Collections.Generic;

namespace PizzaStore.Domain.Models
{
  public class Order
  {
    public List<Pizza> Pizzas { get; }
    public double ordercost;
    public int pizzanum;
    

    public Pizza CreatePizza(string size, string crust, List<string> toppings, string name)
    {
      Pizzas.Add(new Pizza(size, crust, toppings, name));
      pizzanum = 1 + pizzanum;
      return Pizzas[pizzanum - 1];
      
    }

    public Order()
    {
      Pizzas = new List<Pizza>();
      ordercost = 0;
      pizzanum = 0;
    }

    public void RemovePizza(int x)
    {
      x = x - 1;
      Pizza p = Pizzas[x];
      double PriceAdjust = p.Price();
      Pizzas.RemoveAt(x);
      ordercost = ordercost - PriceAdjust; 
      pizzanum = pizzanum - 1;
    }

    
    

  }

}