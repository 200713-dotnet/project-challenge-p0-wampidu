using System.Collections.Generic;
using System.Text;

namespace PizzaStore.Domain.Models
{
  public class Store
  {
    public List<Order> Orders {get;}
    public string StoreName {get; set;}

    public Store()
    {
      Orders = new List<Order>();
    }

    public void PrintOrders()
    {
      //var sb = new StringBuilder();
      foreach(var t in Orders)
      {
        //sb.Append(t + ", ");
        System.Console.WriteLine(Orders);
      }
    }
  }
}