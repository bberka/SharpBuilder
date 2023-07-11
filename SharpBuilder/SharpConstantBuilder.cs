using SharpBuilder.Enums;
using SharpBuilder.Models;

namespace SharpBuilder;

public class SharpConstantBuilder
{
  private readonly SharpConstant _constant;

  public SharpConstantBuilder() {
    _constant = new SharpConstant();
  }

  public SharpConstantBuilder WithAccessModifier(AccessModifier accessModifier) {
    _constant.AccessModifier = accessModifier;
    return this;
  }


  public SharpConstantBuilder WithName(string name) {
    _constant.Name = name;
    return this;
  }

  public SharpConstantBuilder WithValueType(Type valueType) {
    _constant.ValueType = valueType;
    return this;
  }

  public SharpConstantBuilder WithValue(object value) {
    _constant.Value = value;
    return this;
  }


  public SharpConstant Build() {
    return _constant;
  }
}