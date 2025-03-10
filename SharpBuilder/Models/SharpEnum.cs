using System;
using System.Collections.Generic;
using System.Text;
using SharpBuilder.Abstract;
using SharpBuilder.Enums;

namespace SharpBuilder.Models
{
  public sealed class SharpEnum : SharpMaterial
  {
    internal SharpEnum(string name) {
      Name = name;
    }

    public string Name { get; internal set; }
    public List<SharpEnumKey> Keys { get; internal set; } = new List<SharpEnumKey>();
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

      sb.AppendLine("public enum " + Name);
      sb.Append("{");

      foreach (var key in Keys) {
        key.Compile(sb);
      }

      sb.Append("}");
    }
  }
}