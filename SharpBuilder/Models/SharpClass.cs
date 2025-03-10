using System;
using System.Collections.Generic;
using System.Text;
using SharpBuilder.Abstract;
using SharpBuilder.Enums;

namespace SharpBuilder.Models
{
  public sealed class SharpClass : SharpMaterial
  {
    internal SharpClass(string name) {
      Name = name;
    }

    public string Name { get; internal set; }
    public List<SharpClass> Classes { get; internal set; } = new List<SharpClass>();
    public List<SharpEnum> Enums { get; internal set; } = new List<SharpEnum>();
    public List<SharpProperty> Properties { get; internal set; } = new List<SharpProperty>();
    public List<SharpField> Fields { get; internal set; } = new List<SharpField>();
    public List<SharpConstant> Constants { get; internal set; } = new List<SharpConstant>();
    public List<SharpAttribute> Attributes { get; internal set; } = new List<SharpAttribute>();
    public AccessModifier AccessModifier { get; internal set; } = AccessModifier.Public;
    public ClassKeyword? Keyword { get; internal set; }
    public List<string> InheritanceList { get; internal set; } = new List<string>();
    public SharpSummary Summary { get; internal set; }


    public override void Compile(StringBuilder sb) {
      if (string.IsNullOrEmpty(Name)) {
        throw new ArgumentNullException(nameof(Name));
      }

      if (Classes.Contains(this)) {
        throw new InvalidOperationException("Classes can not contain self.");
      }

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

      sb.Append(AccessModifier.ToString().ToLower());
      sb.Append(' ');
      if (Keyword != null) {
        sb.Append(Keyword.ToString()?.ToLower());
        sb.Append(' ');
      }

      sb.Append("class");
      sb.Append(' ');
      sb.Append(Name);
      if (InheritanceList.Count > 0) {
        sb.Append(" : ");
        sb.Append(string.Join(", ", InheritanceList));
      }

      sb.AppendLine(" {");


      foreach (var eEnum in Enums) eEnum.Compile(sb);

      foreach (var constant in Constants) constant.Compile(sb);


      foreach (var field in Fields) field.Compile(sb);

      foreach (var prop in Properties) prop.Compile(sb);

      sb.AppendLine("}");
    }
  }
}