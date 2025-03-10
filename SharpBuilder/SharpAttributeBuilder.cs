using System;
using System.Collections.Generic;
using System.Linq;
using SharpBuilder.Abstract;
using SharpBuilder.Models;

namespace SharpBuilder
{
  public sealed class SharpAttributeBuilder : SharpMaterialBuilder
  {
    private readonly SharpAttribute _attribute;

    public SharpAttributeBuilder(string attributeName) {
      _attribute = new SharpAttribute(attributeName);
    }

    public SharpAttributeBuilder OverrideAttributeName(string attributeName) {
      EnsureNotBuilt();
      _attribute.AttributeName = attributeName;
      return this;
    }

    public SharpAttributeBuilder AddParameters(IEnumerable<object> parameters) {
      EnsureNotBuilt();
      _attribute.Parameters.AddRange(parameters);
      return this;
    }

    public SharpAttributeBuilder SetParameters(IEnumerable<object> parameters) {
      EnsureNotBuilt();
      _attribute.Parameters = parameters.ToList();
      return this;
    }

    public SharpAttributeBuilder AddParameter(object parameter) {
      EnsureNotBuilt();
      _attribute.Parameters.Add(parameter);
      return this;
    }

    public SharpAttributeBuilder SetPropertyParameters(Dictionary<string, object> propertyParameters) {
      EnsureNotBuilt();
      _attribute.PropertyParameters = propertyParameters;
      return this;
    }

    public SharpAttributeBuilder AddPropertyParameters(Dictionary<string, object> propertyParameters) {
      EnsureNotBuilt();
      foreach (var kp in propertyParameters) {
        _attribute.PropertyParameters.Add(kp.Key, kp.Value);
      }

      return this;
    }

    public SharpAttributeBuilder AddPropertyParameter(string propertyName, object propertyValue) {
      EnsureNotBuilt();
      _attribute.PropertyParameters.Add(propertyName, propertyValue);
      return this;
    }


    public SharpAttribute Build() {
      SetBuilt();
      return _attribute;
    }
  }
}