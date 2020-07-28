using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PizzaStore.Domain.Models
{
  public class Pizza
  {
    //STATES
    //fields
    
    private readonly string _imageUrl = null;
    public double diameter = 0;
    public double cost = 0;
    public string Size = "";
    public List<string> Toppings = new List<string>();
    public string Crust = "";
    public string Name = "";

    //properties
    public string SizeP { get;}

    //public string Crust {get;}

    //BEHAVIORS
    //methods
    
    //finalizers or destructors
    void AddToppings(string topping)
    {
      Toppings.Add(topping);
    }

    public double Price()
    {
      if (Size.Equals("small"))
      {
        cost = 5;
      }
      else if (Size.Equals("medium"))
      {
        cost = 7;
      }
      else if (Size.Equals("large"))
      {
        cost = 9;
      }
      return cost;
    }

    public override string ToString()
    {
      
      var sb = new StringBuilder();
      foreach(var t in Toppings)
      {
        sb.Append(t + ", ");
      }

      return $"{Crust} {Size} {sb}";
    }

    //constructors
    public Pizza(string size, string crust, List<string> toppings, string name)
    {
      Size = size;
      Crust = crust;
      Toppings.AddRange(toppings);
      Name = name;
    }
    public Pizza()
    {
      //intentionally empty for the FileManager
    }
  }
}