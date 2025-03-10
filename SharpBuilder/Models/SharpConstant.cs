using System;
using System.Collections.Generic;
using System.Text;
using SharpBuilder.Abstract;
using SharpBuilder.Enums;
using SharpBuilder.Internal;

namespace SharpBuilder.Models
{
  public sealed class SharpConstant : SharpMaterial
  {
    internal SharpConstant(string name, Type valueType, object value) {
      Name = name;
      ValueType = valueType ?? throw new ArgumentNullException(nameof(valueType));
      Value = value;
    }

    public AccessModifier AccessModifier { get; internal set; } = AccessModifier.Public;
    public string Name { get; internal set; }
    public Type ValueType { get; internal set; }
    public object Value { get; internal set; }

    public List<SharpAttribute> Attributes { get; internal set; } = new List<SharpAttribute>();

    public SharpSummary Summary { get; internal set; }


    public override void Compile(StringBuilder sb) {
      if (string.IsNullOrEmpty(Name)) {
        throw new ArgumentNullException(nameof(Name));
      }

      sb.AppendLine();
      if (Summary != null) {
        Summary?.Compile(sb);
        sb.AppendLine();
      }

      if (Attributes.Count > 0) {
        sb.AppendLine();
        foreach (var attribute in Attributes) {
          attribute.Compile(sb);
          sb.AppendLine();
        }
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
}