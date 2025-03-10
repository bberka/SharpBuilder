using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpBuilder.Abstract;
using SharpBuilder.Enums;
using SharpBuilder.Internal;

namespace SharpBuilder.Models
{
  public sealed class SharpProperty : SharpMaterial
  {
    internal SharpProperty(string name, Type valueType) {
      Name = name;
      ValueType = valueType ?? throw new ArgumentNullException(nameof(valueType));
    }

    public AccessModifier AccessModifier { get; internal set; } = AccessModifier.Public;
    public AccessModifier GetterAccessModifier { get; internal set; } = AccessModifier.Public;
    public AccessModifier SetterAccessModifier { get; internal set; } = AccessModifier.Public;
    public string Name { get; internal set; }
    public Type ValueType { get; internal set; }
    public bool IsStatic { get; internal set; } = false;
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

      sb.Append(ValueTypeHelper.GetValueTypeName(ValueType));
      sb.Append(' ');
      sb.Append(Name);
      sb.Append(" { ");
      if (GetterAccessModifier != AccessModifier.Public) sb.Append(GetterAccessModifier.ToString().ToLower() + " ");
      sb.Append("get; ");
      if (SetterAccessModifier != AccessModifier.Public) sb.Append(SetterAccessModifier.ToString().ToLower() + " ");
      sb.Append("set; ");
      sb.Append('}');
      sb.AppendLine();
    }
  }
}