using System.Text;
using SharpBuilder.Enums;
using SharpBuilder.Internal;

namespace SharpBuilder.Models;

public class SharpConstant
{
  internal SharpConstant(string name, Type valueType, object value) {
    Name = name;
    ValueType = valueType;
    Value = value;
  }

  public AccessModifier AccessModifier { get; internal set; } = AccessModifier.Public;
  public string Name { get; internal set; }
  public Type ValueType { get; internal set; }
  public object Value { get; internal set; }

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
    sb.Append(ValueTypeHelper.GetValueTypeName(ValueType));
    sb.Append(' ');
    sb.Append(Name);
    sb.Append(" = ");
    sb.Append(Value);
    sb.AppendLine(";");
    sb.AppendLine();
  }
}