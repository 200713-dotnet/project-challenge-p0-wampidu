using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace PizzaStore.Domain.Models
{
  public class FileManager
  {
    //XML = Extensible Markup Language
    //@ means 'use as is'
    private const string _path = @"data/pizza_store.xml"; //the underscore by the name indicates a PRIVATE field
    public Order Read()
    {
      //open file
      var reader = new StreamReader(_path);
      var xml = new XmlSerializer(typeof(Order));
      return xml.Deserialize(reader) as Order;
    }
    public void Write(Order orders)
    {
      //create a file
      //open the file write permissions
      //load content to write
      //convert content to XML
      //write content to file
      //save and close the file

      var writer = new StreamWriter(_path);

      var xml = new XmlSerializer(typeof(Order));

      xml.Serialize(writer, orders);
    }
  }
}