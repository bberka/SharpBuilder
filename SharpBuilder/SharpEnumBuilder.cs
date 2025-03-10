using System;
using System.Collections.Generic;
using System.Linq;
using SharpBuilder.Abstract;
using SharpBuilder.Models;

namespace SharpBuilder
{
  public sealed class SharpEnumBuilder : SharpMaterialBuilder
  {
    private readonly SharpEnum _enum;

    public SharpEnumBuilder(string name) {
      _enum = new SharpEnum(name);
    }

    public SharpEnumBuilder AddKey(SharpEnumKey key) {
      EnsureNotBuilt();
      _enum.Keys.Add(key);
      return this;
    }

    public SharpEnumBuilder AddKeys(IEnumerable<SharpEnumKey> keys) {
      EnsureNotBuilt();
      _enum.Keys.AddRange(keys);
      return this;
    }

    public SharpEnumBuilder ClearKeys() {
      EnsureNotBuilt();
      _enum.Keys.Clear();
      return this;
    }

    public SharpEnumBuilder RemoveKey(SharpEnumKey key) {
      EnsureNotBuilt();
      _enum.Keys.Remove(key);
      return this;
    }

    public SharpEnumBuilder SetKeys(IEnumerable<SharpEnumKey> keys) {
      EnsureNotBuilt();
      _enum.Keys = keys.ToList();
      return this;
    }

    public SharpEnumBuilder AddAttributes(IEnumerable<SharpAttribute> attributes) {
      EnsureNotBuilt();
      _enum.Attributes.AddRange(attributes);
      return this;
    }

    public SharpEnumBuilder AddAttribute(SharpAttribute attribute) {
      EnsureNotBuilt();
      _enum.Attributes.Add(attribute);
      return this;
    }

    public SharpEnumBuilder SetAttributes(IEnumerable<SharpAttribute> attributes) {
      EnsureNotBuilt();
      _enum.Attributes = attributes.ToList();
      return this;
    }


    public SharpEnum Build() {
      SetBuilt();
      return _enum;
    }
  }
}