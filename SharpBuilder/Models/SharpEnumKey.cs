using System;
using System.Collections.Generic;
using System.Text;
using SharpBuilder.Abstract;

namespace SharpBuilder.Models
{
  public sealed class SharpEnumKey : SharpMaterial
  {
    public SharpEnumKey(string name) {
      Name = name;
    }

    public string Name { get; internal set; }
    public int Value { get; internal set; }
    public bool DoSetValue { get; internal set; }

    public List<SharpAttribute> Attributes { get; internal set; } = new List<SharpAttribute>();

    public override void Compile(StringBuilder sb) {
      if (string.IsNullOrEmpty(Name)) {
        throw new ArgumentNullException(nameof(Name));
      }

      if (Attributes.Count > 0) {
        sb.AppendLine();
        foreach (var attribute in Attributes) {
          attribute.Compile(sb);
          sb.AppendLine();
        }
      }

      sb.Append(Name);
      if (DoSetValue) {
        sb.Append('=');
        sb.Append(' ');
        sb.Append(Value);
      }
      else {
        sb.Append(',');
      }
    }
  }
}