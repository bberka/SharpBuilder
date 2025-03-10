using System;
using System.Collections.Generic;
using System.Linq;
using SharpBuilder.Abstract;
using SharpBuilder.Enums;
using SharpBuilder.Models;

namespace SharpBuilder
{
  public sealed class SharpConstantBuilder : SharpMaterialBuilder
  {
    private readonly SharpConstant _constant;

    public SharpConstantBuilder(string name, Type valueType, object value) {
      _constant = new SharpConstant(name, valueType, value);
    }

    public SharpConstantBuilder AddAccessModifier(AccessModifier accessModifier) {
      EnsureNotBuilt();
      _constant.AccessModifier = accessModifier;
      return this;
    }

    public SharpConstantBuilder OverrideName(string name) {
      EnsureNotBuilt();
      _constant.Name = name;
      return this;
    }

    public SharpConstantBuilder OverrideValueType(Type valueType) {
      EnsureNotBuilt();
      _constant.ValueType = valueType;
      return this;
    }

    public SharpConstantBuilder OverrideValue(object value) {
      EnsureNotBuilt();
      _constant.Value = value;
      return this;
    }

    public SharpConstantBuilder AddSummary(SharpSummary summary) {
      EnsureNotBuilt();
      _constant.Summary = summary;
      return this;
    }

    public SharpConstantBuilder AddAttributes(IEnumerable<SharpAttribute> attributes) {
      EnsureNotBuilt();
      _constant.Attributes.AddRange(attributes);
      return this;
    }

    public SharpConstantBuilder AddAttribute(SharpAttribute attribute) {
      EnsureNotBuilt();
      _constant.Attributes.Add(attribute);
      return this;
    }

    public SharpConstantBuilder SetAttributes(IEnumerable<SharpAttribute> attributes) {
      EnsureNotBuilt();
      _constant.Attributes = attributes.ToList();
      return this;
    }

    public SharpConstant Build() {
      SetBuilt();
      return _constant;
    }
  }
}