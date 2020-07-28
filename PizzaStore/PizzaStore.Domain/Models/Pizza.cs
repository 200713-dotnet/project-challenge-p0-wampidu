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
    public string Size = "";
    public List<string> Toppings = new List<string>();
    public string Crust = "";

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
    public Pizza(string size, string crust, List<string> toppings)
    {
      Size = size;
      Crust = crust;
      Toppings.AddRange(toppings);
    }
    public Pizza()
    {
      //intentionally empty for the FileManager
    }
  }
}