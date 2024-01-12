namespace SharpBuilder.Models;


public class SharpAttribute
{

  public string AttributeName { get; internal set; }

  public object[] Parameters { get; internal set; }

  public Dictionary<string,object> PropertyParameters { get; internal set; }
}