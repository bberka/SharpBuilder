using SharpBuilder.Models;

namespace SharpBuilder;

public class SharpAttributeBuilder
{
  private readonly SharpAttribute _sharpAttribute;

  public SharpAttributeBuilder(string attributeName) {
    _sharpAttribute = new SharpAttribute(attributeName);
  }

  public SharpAttributeBuilder OverrideAttributeName(string attributeName) {
    _sharpAttribute.AttributeName = attributeName;
    return this;
  }

  public SharpAttributeBuilder AddParameters(object[] parameters) {
    _sharpAttribute.Parameters = parameters;
    return this;
  }

  public SharpAttributeBuilder AddParameter(object parameter) {
    if (_sharpAttribute.Parameters == null) {
      _sharpAttribute.Parameters = Array.Empty<object>();
    }

    _sharpAttribute.Parameters = _sharpAttribute.Parameters.Append(parameter).ToArray();
    return this;
  }

  public SharpAttributeBuilder AddPropertyParameters(Dictionary<string, object> propertyParameters) {
    _sharpAttribute.PropertyParameters = propertyParameters;
    return this;
  }

  public SharpAttributeBuilder AddPropertyParameter(string propertyName, object propertyValue) {
    if (_sharpAttribute.PropertyParameters == null) {
      _sharpAttribute.PropertyParameters = new Dictionary<string, object>();
    }

    _sharpAttribute.PropertyParameters.Add(propertyName, propertyValue);
    return this;
  }


  public SharpAttribute Build() {
    return _sharpAttribute;
  }
}