using System.Text;
using SharpBuilder.Enums;

namespace SharpBuilder.Models;

public class SharpClass
{
  internal SharpClass(string name) {
    Name = name;
  }

  public string Name { get; internal set; }
  public List<SharpProperty> Properties { get; internal set; } = new();
  public List<SharpField> Fields { get; internal set; } = new();
  public List<SharpConstant> Constants { get; internal set; } = new();
  public List<SharpAttribute> Attributes { get; internal set; } = new();
  public AccessModifier AccessModifier { get; internal set; } = AccessModifier.Public;
  public ClassKeyword? Keyword { get; internal set; }

  public string[] InheritanceList { get; internal set; } = Array.Empty<string>();
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

    foreach (var attribute in Attributes) {
      attribute.Compile(sb);
      sb.AppendLine();
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
    if (InheritanceList.Length > 0) {
      sb.Append(" : ");
      sb.Append(string.Join(", ", InheritanceList));
    }
    sb.AppendLine(" {");
    sb.AppendLine();
    sb.AppendLine();

    foreach (var constant in Constants) constant.Compile(sb);

    foreach (var field in Fields) field.Compile(sb);

    foreach (var prop in Properties) prop.Compile(sb);

    sb.AppendLine("}");
  }
}