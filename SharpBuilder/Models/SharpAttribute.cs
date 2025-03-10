using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpBuilder.Abstract;

namespace SharpBuilder.Models
{
  public sealed class SharpAttribute : SharpMaterial
  {
    public SharpAttribute(string name) {
      AttributeName = name;
    }

    public string AttributeName { get; internal set; }

    public List<object> Parameters { get; internal set; } = new List<object>();

    public Dictionary<string, object> PropertyParameters { get; internal set; } = new Dictionary<string, object>();


    public override void Compile(StringBuilder sb) {
      if (string.IsNullOrEmpty(AttributeName)) {
        throw new ArgumentNullException(nameof(AttributeName));
      }

      sb.Append('[');
      sb.Append(AttributeName);
      if (Parameters.Count > 0) {
        sb.Append('(');
        for (int i = 0; i < Parameters.Count; i++) {
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
          //   sb.Append(StringHelper.EscapeSharpString(p.ToString()!));
          //   sb.Append('"');
          // }
          var isLastParameter = i == Parameters.Count - 1;
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
}