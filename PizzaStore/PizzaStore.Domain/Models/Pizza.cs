using System.Collections.Generic;
using System.Text;

namespace PizzaStore.Domain.Models
{
  public class Pizza
  {
    //STATES
    //fields
    
    string imageUrl = "";
    public double diameter = 0;
    public string Size = "";
    public List<string> Toppings = new List<string>();
    public string Crust = "";

    //properties
    public string SizeP { get;}

    //BEHAVIORS
    //methods
    
    //finalizers or destructors
    void AddToppings(string topping)
    {
      Toppings.Add(topping);
    }

    public override string ToString()
    {
      /*
        string concatenation = immutable
        ex: string1 
        string1 + string2 
        string1 + string2 + string3

        stringbuilder = mutable
        ex: string1 + string2 + string3

      */
      var sb = new StringBuilder();
      foreach(var t in Toppings)
      {
        sb.Append(t);
      }

      return $"{Crust} {Size} {sb}";
    }

    //constructors
    public Pizza(string size, string crust, List<string> toppings)
    {
      Size = size;
      Crust = crust;
      Toppings.AddRange(toppings);
    }
  }
}