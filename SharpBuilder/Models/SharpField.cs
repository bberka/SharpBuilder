using System.Text;
using SharpBuilder.Enums;

namespace SharpBuilder.Models;

public class SharpField
{
  internal SharpField(string name, Type valueType) {
    Name = name;
    ValueType = valueType;
  }

  public AccessModifier AccessModifier { get; internal set; } = AccessModifier.Public;
  public string Name { get; internal set; }
  public Type ValueType { get; internal set; }
  public object? Value { get; internal set; }
  public bool IsStatic { get; internal set; } = false;
  public bool IsReadOnly { get; internal set; } = false;

  public SharpSummary? Summary { get; internal set; }

  public override string ToString() {
    var sb = new StringBuilder();
    Compile(sb);
    return sb.ToString();
  }

  public void Compile(StringBuilder sb) {
    sb.AppendLine();

    if (Summary != null) {
      Summary?.Compile(sb);
      sb.AppendLine();
    }

    sb.Append('\t');
    sb.Append(AccessModifier.ToString().ToLower());
    sb.Append(' ');
    if (IsStatic) {
      sb.Append("static");
      sb.Append(' ');
    }

    if (IsReadOnly) {
      sb.Append("readonly");
      sb.Append(' ');
    }

    sb.Append(ValueType.Name);
    sb.Append(' ');
    sb.Append(Name);
    if (Value != null) {
      sb.Append(" = ");
      sb.Append(Value);
    }

    sb.AppendLine(";");
    sb.AppendLine();
  }
}