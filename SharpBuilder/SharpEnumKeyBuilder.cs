using System.Collections.Generic;
using System.Linq;
using SharpBuilder.Abstract;
using SharpBuilder.Models;

namespace SharpBuilder
{
  public sealed class SharpEnumKeyBuilder : SharpMaterialBuilder
  {
    private readonly SharpEnumKey _enumKey;

    public SharpEnumKeyBuilder(string name) {
      _enumKey = new SharpEnumKey(name);
    }


    public SharpEnumKeyBuilder SetName(string name) {
      EnsureNotBuilt();
      _enumKey.Name = name;
      return this;
    }

    public SharpEnumKeyBuilder WithValue(int value) {
      EnsureNotBuilt();
      _enumKey.Value = value;
      _enumKey.DoSetValue = true;
      return this;
    }

    public SharpEnumKeyBuilder ClearValue() {
      EnsureNotBuilt();
      _enumKey.Value = 0;
      _enumKey.DoSetValue = false;
      return this;
    }

    public SharpEnumKeyBuilder AddAttributes(IEnumerable<SharpAttribute> attributes) {
      EnsureNotBuilt();
      _enumKey.Attributes.AddRange(attributes);
      return this;
    }

    public SharpEnumKeyBuilder AddAttribute(SharpAttribute attribute) {
      EnsureNotBuilt();
      _enumKey.Attributes.Add(attribute);
      return this;
    }

    public SharpEnumKeyBuilder SetAttributes(IEnumerable<SharpAttribute> attributes) {
      EnsureNotBuilt();
      _enumKey.Attributes = attributes.ToList();
      return this;
    }


    public SharpEnumKey Build() {
      SetBuilt();
      return _enumKey;
    }
  }
}