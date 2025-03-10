using System;
using System.Collections.Generic;
using System.Linq;
using SharpBuilder.Abstract;
using SharpBuilder.Enums;
using SharpBuilder.Models;

namespace SharpBuilder
{
  public sealed class SharpFieldBuilder : SharpMaterialBuilder
  {
    private readonly SharpField _field;

    public SharpFieldBuilder(string name, Type valueType) {
      _field = new SharpField(name, valueType);
    }

    public SharpFieldBuilder AddAccessModifier(AccessModifier accessModifier) {
      EnsureNotBuilt();
      _field.AccessModifier = accessModifier;
      return this;
    }


    public SharpFieldBuilder OverrideName(string name) {
      EnsureNotBuilt();
      _field.Name = name;
      return this;
    }

    public SharpFieldBuilder OverrideValueType(Type valueType) {
      EnsureNotBuilt();
      _field.ValueType = valueType;
      return this;
    }

    public SharpFieldBuilder AddValue(object value) {
      EnsureNotBuilt();
      _field.Value = value;
      return this;
    }

    public SharpFieldBuilder Static() {
      EnsureNotBuilt();
      _field.IsStatic = true;
      return this;
    }


    public SharpFieldBuilder Readonly() {
      EnsureNotBuilt();
      _field.IsReadOnly = true;
      return this;
    }

    public SharpFieldBuilder AddSummary(SharpSummary summary) {
      EnsureNotBuilt();
      _field.Summary = summary;
      return this;
    }


    public SharpFieldBuilder AddAttributes(IEnumerable<SharpAttribute> attributes) {
      EnsureNotBuilt();
      _field.Attributes.AddRange(attributes);
      return this;
    }

    public SharpFieldBuilder AddAttribute(SharpAttribute attribute) {
      EnsureNotBuilt();
      _field.Attributes.Add(attribute);
      return this;
    }

    public SharpFieldBuilder SetAttributes(IEnumerable<SharpAttribute> attributes) {
      EnsureNotBuilt();
      _field.Attributes = attributes.ToList();
      return this;
    }

    public SharpField Build() {
      SetBuilt();
      return _field;
    }
  }
}