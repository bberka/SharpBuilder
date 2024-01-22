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


  public SharpClassBuilder AddAccessModifier(AccessModifier accessModifier) {
    _sharpClass.AccessModifier = accessModifier;
    return this;
  }

  public SharpClassBuilder AddKeyword(ClassKeyword classKeyword) {
    _sharpClass.Keyword = classKeyword;
    return this;
  }


  public SharpClassBuilder AddProperties(List<SharpProperty> properties) {
    _sharpClass.Properties = properties;
    return this;
  }

  public SharpClassBuilder AddProperty(SharpProperty property) {
    _sharpClass.Properties ??= new List<SharpProperty>();
    _sharpClass.Properties.Add(property);
    return this;
  }

  public SharpClassBuilder AddFields(List<SharpField> fields) {
    _sharpClass.Fields = fields;
    return this;
  }

  public SharpClassBuilder AddField(SharpField field) {
    _sharpClass.Fields ??= new List<SharpField>();
    _sharpClass.Fields.Add(field);
    return this;
  }

  public SharpClassBuilder AddConstants(List<SharpConstant> constants) {
    _sharpClass.Constants = constants;
    return this;
  }

  public SharpClassBuilder AddInheritanceList(string[] inheritanceList) {
    _sharpClass.InheritanceList = inheritanceList;
    return this;
  }

  public SharpClassBuilder AddInheritance(string inheritance) {
    _sharpClass.InheritanceList ??= Array.Empty<string>();
    _sharpClass.InheritanceList = _sharpClass.InheritanceList.Append(inheritance).ToArray();
    return this;
  }


  public SharpClassBuilder AddConstant(SharpConstant constant) {
    _sharpClass.Constants ??= new List<SharpConstant>();
    _sharpClass.Constants.Add(constant);
    return this;
  }

  public SharpClassBuilder AddAttributes(List<SharpAttribute> attributes) {
    _sharpClass.Attributes = attributes;
    return this;
  }

  public SharpClassBuilder AddAttribute(SharpAttribute attribute) {
    _sharpClass.Attributes ??= new List<SharpAttribute>();
    _sharpClass.Attributes.Add(attribute);
    return this;
  }

  public SharpClassBuilder AddSummary(SharpSummary summary) {
    _sharpClass.Summary = summary;
    return this;
  }

  public SharpClass Build() {
    return _sharpClass;
  }
}