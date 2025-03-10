using System.Collections.Generic;
using System.Linq;
using SharpBuilder.Abstract;
using SharpBuilder.Enums;
using SharpBuilder.Models;

namespace SharpBuilder
{
  public sealed class SharpClassBuilder : SharpMaterialBuilder
  {
    private readonly SharpClass _sharpClass;

    public SharpClassBuilder(string name) {
      _sharpClass = new SharpClass(name);
    }

    public SharpClassBuilder OverrideName(string name) {
      EnsureNotBuilt();
      _sharpClass.Name = name;
      return this;
    }


    public SharpClassBuilder AddAccessModifier(AccessModifier accessModifier) {
      EnsureNotBuilt();
      _sharpClass.AccessModifier = accessModifier;
      return this;
    }

    public SharpClassBuilder AddKeyword(ClassKeyword classKeyword) {
      EnsureNotBuilt();
      _sharpClass.Keyword = classKeyword;
      return this;
    }


    public SharpClassBuilder SetProperties(IEnumerable<SharpProperty> properties) {
      EnsureNotBuilt();
      _sharpClass.Properties = properties.ToList();
      return this;
    }

    public SharpClassBuilder AddProperties(IEnumerable<SharpProperty> properties) {
      EnsureNotBuilt();
      _sharpClass.Properties.AddRange(properties);
      return this;
    }

    public SharpClassBuilder AddProperty(SharpProperty property) {
      EnsureNotBuilt();
      _sharpClass.Properties.Add(property);
      return this;
    }

    public SharpClassBuilder SetFields(IEnumerable<SharpField> fields) {
      EnsureNotBuilt();
      _sharpClass.Fields = fields.ToList();
      return this;
    }

    public SharpClassBuilder AddFields(IEnumerable<SharpField> fields) {
      EnsureNotBuilt();
      _sharpClass.Fields.AddRange(fields.ToList());
      return this;
    }

    public SharpClassBuilder AddField(SharpField field) {
      EnsureNotBuilt();
      _sharpClass.Fields.Add(field);
      return this;
    }

    public SharpClassBuilder SetConstants(IEnumerable<SharpConstant> constants) {
      EnsureNotBuilt();
      _sharpClass.Constants = constants.ToList();
      return this;
    }

    public SharpClassBuilder AddConstants(IEnumerable<SharpConstant> constants) {
      EnsureNotBuilt();
      _sharpClass.Constants.AddRange(constants);
      return this;
    }

    public SharpClassBuilder SetInheritanceList(IEnumerable<string> inheritanceList) {
      EnsureNotBuilt();
      _sharpClass.InheritanceList = inheritanceList.ToList();
      return this;
    }

    public SharpClassBuilder AddInheritanceList(IEnumerable<string> inheritanceList) {
      EnsureNotBuilt();
      _sharpClass.InheritanceList.AddRange(inheritanceList);
      return this;
    }

    public SharpClassBuilder AddInheritance(string inheritance) {
      EnsureNotBuilt();
      _sharpClass.InheritanceList.Add(inheritance);
      return this;
    }


    public SharpClassBuilder AddConstant(SharpConstant constant) {
      EnsureNotBuilt();
      _sharpClass.Constants.Add(constant);
      return this;
    }

    public SharpClassBuilder AddAttributes(IEnumerable<SharpAttribute> attributes) {
      EnsureNotBuilt();
      _sharpClass.Attributes.AddRange(attributes);
      return this;
    }

    public SharpClassBuilder AddAttribute(SharpAttribute attribute) {
      EnsureNotBuilt();
      _sharpClass.Attributes.Add(attribute);
      return this;
    }

    public SharpClassBuilder SetAttributes(IEnumerable<SharpAttribute> attributes) {
      EnsureNotBuilt();
      _sharpClass.Attributes = attributes.ToList();
      return this;
    }

    public SharpClassBuilder AddSummary(SharpSummary summary) {
      EnsureNotBuilt();
      _sharpClass.Summary = summary;
      return this;
    }

    public SharpClass Build() {
      SetBuilt();
      return _sharpClass;
    }
  }
}