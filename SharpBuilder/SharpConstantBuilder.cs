using SharpBuilder.Enums;
using SharpBuilder.Models;

namespace SharpBuilder;

public class SharpConstantBuilder
{
  private readonly SharpConstant _constant;

  public SharpConstantBuilder(string name, Type valueType, object value) {
    _constant = new SharpConstant(name, valueType, value);
  }

  public SharpConstantBuilder WithAccessModifier(AccessModifier accessModifier) {
    _constant.AccessModifier = accessModifier;
    return this;
  }

  public SharpConstantBuilder OverrideName(string name) {
    _constant.Name = name;
    return this;
  }

  public SharpConstantBuilder OverrideValueType(Type valueType) {
    _constant.ValueType = valueType;
    return this;
  }

  public SharpConstantBuilder OverrideValue(object value) {
    _constant.Value = value;
    return this;
  }

  public SharpConstantBuilder WithSummary(SharpSummary summary) {
    _constant.Summary = summary;
    return this;
  }

  public SharpConstant Build() {
    return _constant;
  }
}