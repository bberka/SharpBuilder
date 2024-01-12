using SharpBuilder.Enums;
using SharpBuilder.Models;

namespace SharpBuilder;

public class SharpClassBuilder
{
  private readonly SharpClass _sharpClass;

  public SharpClassBuilder() {
    _sharpClass = new SharpClass();
  }

  public SharpClassBuilder WithUsing(string usingString) {
    _sharpClass.UsingList.Add(usingString);
    return this;
  }

  public SharpClassBuilder WithUsingList(List<string> list) {
    _sharpClass.UsingList = list;
    return this;
  }

  public SharpClassBuilder WithNameSpace(string nameSpace) {
    _sharpClass.NameSpace = nameSpace;
    return this;
  }


  public SharpClassBuilder WithAccessModifier(AccessModifier accessModifier) {
    _sharpClass.AccessModifier = accessModifier;
    return this;
  }
  public SharpClassBuilder WithKeyword(Keyword keyword) {
    _sharpClass.Keyword = keyword;
    return this;
  }

  public SharpClassBuilder WithName(string name) {
    _sharpClass.Name = name;
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

  //public SharpClassBuilder WithType(FileType fileType) {
  //  _sharpClass.Type = fileType;
  //  return this;
  //}

  public SharpClass Build() {
    return _sharpClass;
  }

}