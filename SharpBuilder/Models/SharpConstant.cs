using SharpBuilder.Enums;

namespace SharpBuilder.Models;

public class SharpConstant
{
  internal SharpConstant() {
    
  }
  public AccessModifier AccessModifier { get; internal set; }
  public string Name { get; internal set; }
  public Type ValueType { get; internal set; }
  public object Value { get; internal set; }
}