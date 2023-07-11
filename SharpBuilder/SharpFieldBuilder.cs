using SharpBuilder.Enums;
using SharpBuilder.Models;

namespace SharpBuilder;

public class SharpFieldBuilder
{
  private readonly SharpField _field;

  public SharpFieldBuilder() {
    _field = new SharpField();
  }

  public SharpFieldBuilder WithAccessModifier(AccessModifier accessModifier) {
    _field.AccessModifier = accessModifier;
    return this;
  }


  public SharpFieldBuilder WithName(string name) {
    _field.Name = name;
    return this;
  }

  public SharpFieldBuilder WithName(object value) {
    _field.Value = value;
    return this;
  }
  public SharpFieldBuilder WithValueType(Type valueType) {
    _field.ValueType = valueType;
    return this;
  }
  public SharpFieldBuilder WithValue(object value) {
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

  public SharpField Build() {
    return _field;
  }
}