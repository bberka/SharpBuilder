using SharpBuilder.Enums;

namespace SharpBuilder.Models;

public class SharpProperty
{
  internal SharpProperty() {

  }
  public AccessModifier AccessModifier { get; internal set; }
  public AccessModifier GetterAccessModifier { get; internal set; }
  public AccessModifier SetterAccessModifier { get; internal set; }
  public string Name { get; internal set; }
  public Type ValueType { get; internal set; }
  public bool IsStatic { get; internal set; } = false;

}