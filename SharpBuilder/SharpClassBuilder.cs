using SharpBuilder.Enums;
using SharpBuilder.Models;

namespace SharpBuilder;

public class SharpClassBuilder
{
  private readonly SharpClass _sharpClass;

  public SharpClassBuilder(string name) {
    _sharpClass = new SharpClass(name);
  }

  public SharpClassBuilder OverrideName(string name) {
    _sharpClass.Name = name;
    return this;
  }


  public SharpClassBuilder WithAccessModifier(AccessModifier accessModifier) {
    _sharpClass.AccessModifier = accessModifier;
    return this;
  }

  public SharpClassBuilder WithKeyword(ClassKeyword classKeyword) {
    _sharpClass.Keyword = classKeyword;
    return this;
  }


  public SharpClassBuilder WithProperties(List<SharpProperty> properties) {
    _sharpClass.Properties = properties;
    return this;
  }

  public SharpClassBuilder WithProperty(SharpProperty property) {
    _sharpClass.Properties ??= new List<SharpProperty>();
    _sharpClass.Properties.Add(property);
    return this;
  }

  public SharpClassBuilder WithFields(List<SharpField> fields) {
    _sharpClass.Fields = fields;
    return this;
  }

  public SharpClassBuilder WithField(SharpField field) {
    _sharpClass.Fields ??= new List<SharpField>();
    _sharpClass.Fields.Add(field);
    return this;
  }

  public SharpClassBuilder WithConstants(List<SharpConstant> constants) {
    _sharpClass.Constants = constants;
    return this;
  }

  public SharpClassBuilder WithConstant(SharpConstant constant) {
    _sharpClass.Constants ??= new List<SharpConstant>();
    _sharpClass.Constants.Add(constant);
    return this;
  }

  public SharpClassBuilder WithAttributes(List<SharpAttribute> attributes) {
    _sharpClass.Attributes = attributes;
    return this;
  }

  public SharpClassBuilder WithAttribute(SharpAttribute attribute) {
    _sharpClass.Attributes ??= new List<SharpAttribute>();
    _sharpClass.Attributes.Add(attribute);
    return this;
  }

  public SharpClassBuilder WithSummary(SharpSummary summary) {
    _sharpClass.Summary = summary;
    return this;
  }

  public SharpClass Build() {
    return _sharpClass;
  }
}