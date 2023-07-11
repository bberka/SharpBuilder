using System.Text;
using SharpBuilder.Enums;
using SharpBuilder.Models;


namespace SharpBuilder;

public static class SharpExtensions
{
  public static void Export(this SharpClass sharpClass, string fileNameWithoutExtension) {
    var sb = new StringBuilder();
    foreach (var item in sharpClass.UsingList) {
      sb.AppendLine("using " + item + ";");
    }
    sb.AppendLine();
    sb.AppendLine("namespace " + sharpClass.NameSpace + ";");
    sb.AppendLine();
    sb.Append(sharpClass.AccessModifier.ToString().ToLower());
    sb.Append(" ");
    sb.Append(sharpClass.Keyword.ToString().ToLower());
    sb.Append(" ");
    sb.Append("class");
    sb.Append(" ");
    sb.Append(sharpClass.Name);
    sb.Append(" {");
    sb.AppendLine();

    foreach (var constant in sharpClass.Constants) {
      sb.Append("\t");
      sb.Append(constant.AccessModifier.ToString().ToLower());
      sb.Append(" ");
      sb.Append(constant.ValueType.Name);
      sb.Append(" ");
      sb.Append(constant.Name);
      sb.Append(" = ");
      sb.Append(constant.Value);
      sb.AppendLine(";");
      sb.AppendLine();
    }

    foreach (var field in sharpClass.Fields) {
      sb.Append("\t");
      sb.Append(field.AccessModifier.ToString().ToLower());
      sb.Append(" ");
      if (field.IsStatic) {
        sb.Append("static");
        sb.Append(" ");
      }
      if (field.IsReadOnly) {
        sb.Append("readonly");
        sb.Append(" ");
      }
      sb.Append(field.ValueType.Name);
      sb.Append(" ");
      sb.Append(field.Name);
      if (field.Value != null) {
        sb.Append(" = ");
        sb.Append(field.Value);
      }
      sb.AppendLine(";");
      sb.AppendLine();

    }
    foreach (var prop in sharpClass.Properties) {
      sb.Append("\t");
      sb.Append(prop.AccessModifier.ToString().ToLower());
      sb.Append(" ");

      if (prop.IsStatic) {
        sb.Append("static");
        sb.Append(" ");
      }
      sb.Append(prop.ValueType.Name);
      sb.Append(" ");
      sb.Append(prop.Name);
      sb.Append(" { ");
      if (prop.GetterAccessModifier != AccessModifier.Public) {
        sb.Append(prop.GetterAccessModifier.ToString().ToLower() + " ");
      }
      sb.Append("get;");
      if (prop.SetterAccessModifier != AccessModifier.Public) {
        sb.Append(prop.SetterAccessModifier.ToString().ToLower() + " ");
      }
      sb.Append("set;");
      sb.Append("}");
      sb.AppendLine();
    }
    sb.AppendLine("}");
    var text = sb.ToString();
    File.WriteAllText(fileNameWithoutExtension + ".cs", text);
  }
}
