using PizzaStore.Domain.Models;
using System.Collections.Generic;
using Xunit;


namespace PizzaStore.Testing.Tests
{
  public class OrderTest
  {
    [Theory]
    [InlineData("S","C","T","N")]
    [InlineData("M","C2","T2","N2")]
    public void Test_CreatePizza(string s, string c, string t, string n)
    {
      
      //arrange
      var sut = new Order();
      string size = s;
      string crust = c;
      string name = n;
      List<string> toppings = new List<string>{t};

      //act
      sut.CreatePizza(size, crust, toppings, name);

      //assert
      Assert.True(sut.Pizzas.Count > 0);
    }
  }
}