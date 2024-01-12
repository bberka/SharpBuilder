using System.Text;

namespace SharpBuilder.Models;

public class SharpAttribute
{
  public SharpAttribute(string attributeName) {
    AttributeName = attributeName;
  }

  public string AttributeName { get; internal set; }

  public object[] Parameters { get; internal set; } = Array.Empty<object>();

  public Dictionary<string, object> PropertyParameters { get; internal set; } = new();

  public string Compile() {
    var sb = new StringBuilder();
    Compile(sb);
    return sb.ToString();
  }

  public void Compile(StringBuilder sb) {
    sb.Append('[');
    sb.Append(AttributeName);
    if (Parameters.Length > 0) {
      sb.Append('(');
      sb.Append(string.Join(", ", Parameters));
      sb.Append(')');
    }

    if (PropertyParameters.Count > 0) {
      sb.Append('(');
      sb.Append(string.Join(", ", PropertyParameters.Select(x => x.Key + " = " + x.Value)));
      sb.Append(')');
    }

    sb.Append(']');
  }
}