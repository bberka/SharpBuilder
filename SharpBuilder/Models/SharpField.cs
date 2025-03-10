using System;
using System.Collections.Generic;
using System.Text;
using SharpBuilder.Abstract;
using SharpBuilder.Enums;
using SharpBuilder.Internal;

namespace SharpBuilder.Models
{
  public sealed class SharpField : SharpMaterial
  {
    internal SharpField(string name, Type valueType) {
      Name = name;
      ValueType = valueType ?? throw new ArgumentNullException(nameof(valueType));
    }

    public AccessModifier AccessModifier { get; internal set; } = AccessModifier.Public;
    public string Name { get; internal set; }
    public Type ValueType { get; internal set; }
    public object Value { get; internal set; }
    public bool IsStatic { get; internal set; } = false;
    public bool IsReadOnly { get; internal set; } = false;
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
      if (IsStatic) {
        sb.Append("static");
        sb.Append(' ');
      }

      if (IsReadOnly) {
        sb.Append("readonly");
        sb.Append(' ');
      }

      sb.Append(ValueTypeHelper.GetValueTypeName(ValueType));
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
}