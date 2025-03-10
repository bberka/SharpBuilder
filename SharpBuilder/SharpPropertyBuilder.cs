using System;
using System.Collections.Generic;
using System.Linq;
using SharpBuilder.Abstract;
using SharpBuilder.Enums;
using SharpBuilder.Models;

namespace SharpBuilder
{
  public sealed class SharpPropertyBuilder : SharpMaterialBuilder
  {
    private readonly SharpProperty _property;

    public SharpPropertyBuilder(string name, Type valueType) {
      _property = new SharpProperty(name, valueType);
    }

    public SharpPropertyBuilder OverrideName(string name) {
      EnsureNotBuilt();
      _property.Name = name;
      return this;
    }

    public SharpPropertyBuilder OverrideValueType(Type valueType) {
      EnsureNotBuilt();
      _property.ValueType = valueType;
      return this;
    }

    public SharpPropertyBuilder AddAccessModifier(AccessModifier accessModifier) {
      EnsureNotBuilt();
      _property.AccessModifier = accessModifier;
      return this;
    }

    public SharpPropertyBuilder AddGetterAccessModifier(AccessModifier getterAccessModifier) {
      EnsureNotBuilt();
      _property.GetterAccessModifier = getterAccessModifier;
      return this;
    }

    public SharpPropertyBuilder AddSetterAccessModifier(AccessModifier setterAccessModifier) {
      EnsureNotBuilt();
      _property.SetterAccessModifier = setterAccessModifier;
      return this;
    }


    public SharpPropertyBuilder Static() {
      EnsureNotBuilt();
      _property.IsStatic = true;
      return this;
    }

    public SharpPropertyBuilder AddAttributes(IEnumerable<SharpAttribute> attributes) {
      EnsureNotBuilt();
      _property.Attributes.AddRange(attributes);
      return this;
    }

    public SharpPropertyBuilder AddAttribute(SharpAttribute attribute) {
      EnsureNotBuilt();
      _property.Attributes.Add(attribute);
      return this;
    }

    public SharpPropertyBuilder SetAttributes(IEnumerable<SharpAttribute> attributes) {
      EnsureNotBuilt();
      _property.Attributes = attributes.ToList();
      return this;
    }


    public SharpPropertyBuilder AddSummary(SharpSummary summary) {
      EnsureNotBuilt();
      _property.Summary = summary;
      return this;
    }

    public SharpProperty Build() {
      SetBuilt();
      return _property;
    }
  }
}