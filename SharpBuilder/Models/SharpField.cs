using SharpBuilder.Enums;

namespace SharpBuilder.Models;

public class SharpField
{
  internal SharpField() {
    
  }
  public AccessModifier AccessModifier { get; internal set; }
  public string Name { get; internal set; }
  public Type ValueType { get; internal set; }
  public object? Value { get; internal set; }
  public bool IsStatic { get; internal  set; } = false;
  public bool IsReadOnly { get; internal set; } = false;
}