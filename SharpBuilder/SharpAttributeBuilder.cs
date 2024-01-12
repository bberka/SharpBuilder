using SharpBuilder.Models;

namespace SharpBuilder;

public class SharpAttributeBuilder
{
  private readonly SharpAttribute _sharpAttribute;

  public SharpAttributeBuilder() {
    _sharpAttribute = new SharpAttribute();
  }
  
  public SharpAttributeBuilder WithAttributeName(string attributeName) {
    _sharpAttribute.AttributeName = attributeName;
    return this;
  }
  
  public SharpAttributeBuilder WithParameters(object[] parameters) {
    _sharpAttribute.Parameters = parameters;
    return this;
  }
  
  public SharpAttributeBuilder WithPropertyParameters(Dictionary<string, object> propertyParameters) {
    _sharpAttribute.PropertyParameters = propertyParameters;
    return this;
  }
  
  public SharpAttribute Build() {
    return _sharpAttribute;
  }
}