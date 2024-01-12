using System.Text;
using SharpBuilder.Internal;

namespace SharpBuilder.Models;

public class SharpAttribute
{
  public SharpAttribute(string attributeName) {
    AttributeName = attributeName;
  }

  public string AttributeName { get; internal set; }

  public object[] Parameters { get; internal set; } = Array.Empty<object>();

  public Dictionary<string, object> PropertyParameters { get; internal set; } = new();

  public override string ToString() {
    var sb = new StringBuilder();
    Compile(sb);
    return sb.ToString();
  }

  public void Compile(StringBuilder sb) {
    sb.Append('[');
    sb.Append(AttributeName);
    if (Parameters.Length > 0) {
      sb.Append('(');
      foreach (var p in Parameters) {
        var isString = p is string;
        if (isString) {
          sb.Append('"');
          sb.Append(StringHelper.EscapeCSharpString(p.ToString()!));
          sb.Append('"');
        }
        else
          sb.Append(p);
      }
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