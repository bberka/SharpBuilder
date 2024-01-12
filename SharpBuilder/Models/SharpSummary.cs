using System.Text;

namespace SharpBuilder.Models;

/// <summary>
/// </summary>
public class SharpSummary
{
  public SharpSummary(string text) {
    Text = text;
  }

  public string Text { get; internal set; }

  //TODO Add param etc.
  //TODO Add auto creation for template xml

  public override string ToString() {
    var sb = new StringBuilder();
    Compile(sb);
    return sb.ToString();
  }

  public void Compile(StringBuilder sb) {
    sb.AppendLine("/// <summary>");
    sb.AppendLine($"/// {Text}");
    sb.AppendLine("/// </summary>");
  }
}