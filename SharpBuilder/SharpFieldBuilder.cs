using SharpBuilder.Enums;
using SharpBuilder.Models;

namespace SharpBuilder;

public class SharpFieldBuilder
{
  private readonly SharpField _field;

  public SharpFieldBuilder(string name, Type valueType) {
    _field = new SharpField(name, valueType);
  }

  public SharpFieldBuilder AddAccessModifier(AccessModifier accessModifier) {
    _field.AccessModifier = accessModifier;
    return this;
  }


  public SharpFieldBuilder OverrideName(string name) {
    _field.Name = name;
    return this;
  }

  public SharpFieldBuilder OverrideValueType(Type valueType) {
    _field.ValueType = valueType;
    return this;
  }

  public SharpFieldBuilder AddValue(object value) {
    _field.Value = value;
    return this;
  }

  public SharpFieldBuilder Static() {
    _field.IsStatic = true;
    return this;
  }


  public SharpFieldBuilder Readonly() {
    _field.IsReadOnly = true;
    return this;
  }

  public SharpFieldBuilder AddSummary(SharpSummary summary) {
    _field.Summary = summary;
    return this;
  }

  public SharpField Build() {
    return _field;
  }
}