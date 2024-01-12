using SharpBuilder.Enums;
using SharpBuilder.Models;

namespace SharpBuilder;

public class SharpPropertyBuilder
{
    private readonly SharpProperty _property;

    public SharpPropertyBuilder() {
        _property = new SharpProperty();
    }

    public SharpPropertyBuilder WithAccessModifier(AccessModifier accessModifier) {
        _property.AccessModifier = accessModifier;
        return this;
    }

    public SharpPropertyBuilder WithGetterAccessModifier(AccessModifier getterAccessModifier) {
        _property.GetterAccessModifier = getterAccessModifier;
        return this;
    }

    public SharpPropertyBuilder WithSetterAccessModifier(AccessModifier setterAccessModifier) {
        _property.SetterAccessModifier = setterAccessModifier;
        return this;
    }

    public SharpPropertyBuilder WithName(string name) {
        _property.Name = name;
        return this;
    }

    public SharpPropertyBuilder WithValueType(Type valueType) {
        _property.ValueType = valueType;
        return this;
    }


    public SharpPropertyBuilder Static() {
        _property.IsStatic = true;
        return this;
    }
    
    public SharpPropertyBuilder WithAttributes(List<SharpAttribute> attributes) {
        _property.Attributes = attributes;
        return this;
    }
    
    public SharpPropertyBuilder WithAttribute(SharpAttribute attribute) {
        _property.Attributes ??= new List<SharpAttribute>();
        _property.Attributes.Add(attribute);
        return this;
    }

    public SharpProperty Build() {
        return _property;
    }
}