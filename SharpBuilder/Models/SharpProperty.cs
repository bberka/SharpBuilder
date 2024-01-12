using System.Text;
using SharpBuilder.Enums;

namespace SharpBuilder.Models;

[Serializable]
public class SharpProperty
{
  internal SharpProperty(string name, Type valueType) {
    Name = name;
    ValueType = valueType;
  }

  public AccessModifier AccessModifier { get; internal set; } = AccessModifier.Public;
  public AccessModifier GetterAccessModifier { get; internal set; } = AccessModifier.Public;
  public AccessModifier SetterAccessModifier { get; internal set; } = AccessModifier.Public;
  public string Name { get; internal set; }
  public Type ValueType { get; internal set; }
  public bool IsStatic { get; internal set; } = false;
  public List<SharpAttribute> Attributes { get; internal set; } = new();

  public SharpSummary? Summary { get; internal set; }

  public override string ToString() {
    var sb = new StringBuilder();
    Compile(sb);
    return sb.ToString();
  }

  public void Compile(StringBuilder sb) {
    if (Summary != null) {
      Summary?.Compile(sb);
      sb.AppendLine();
    }

    if (Attributes.Count > 0)
      foreach (var attribute in Attributes) {
        sb.Append('[');
        sb.Append(attribute.AttributeName);
        if (attribute.Parameters.Length > 0) {
          sb.Append('(');
          sb.Append(string.Join(", ", attribute.Parameters));
          sb.Append(')');
        }

        if (attribute.PropertyParameters.Count > 0) {
          sb.Append('(');
          sb.Append(string.Join(", ", attribute.PropertyParameters.Select(x => x.Key + " = " + x.Value)));
          sb.Append(')');
        }

        sb.Append(']');
        sb.AppendLine();
      }

    sb.Append(AccessModifier.ToString().ToLower());
    sb.Append(' ');

    if (IsStatic) {
      sb.Append("static");
      sb.Append(' ');
    }

    sb.Append(ValueType.Name);
    sb.Append(' ');
    sb.Append(Name);
    sb.Append(" { ");
    if (GetterAccessModifier != AccessModifier.Public) sb.Append(GetterAccessModifier.ToString().ToLower() + " ");

    sb.Append("get;");
    if (SetterAccessModifier != AccessModifier.Public) sb.Append(SetterAccessModifier.ToString().ToLower() + " ");

    sb.Append("set;");
    sb.Append('}');
  }
}