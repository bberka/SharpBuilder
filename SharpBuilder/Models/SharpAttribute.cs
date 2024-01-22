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
      for (int i = 0; i < Parameters.Length; i++) {
        var p = Parameters[i];
        var isString = p is string;
        if (isString) sb.Append('"');
        sb.Append(p);
        if (isString) sb.Append('"');

        // if (p is bool b) {
        //   sb.Append(b
        //               ? "true"
        //               : "false");
        // }
        // else if (p is char c) {
        //   sb.Append('\'');
        //   sb.Append(c);
        //   sb.Append('\'');
        // }
        // else if (p is null) {
        //   sb.Append("null");
        // }
        // else if (p is Enum) {
        //   sb.Append(p.GetType().Name);
        //   sb.Append('.');
        //   sb.Append(p);
        // }
        // else {
        //   sb.Append('"');
        //   sb.Append(StringHelper.EscapeCSharpString(p.ToString()!));
        //   sb.Append('"');
        // }
        var isLastParameter = i == Parameters.Length - 1;
        if (!isLastParameter) sb.Append(", ");
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