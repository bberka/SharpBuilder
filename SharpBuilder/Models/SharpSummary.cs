using System.Text;
using SharpBuilder.Abstract;

namespace SharpBuilder.Models
{
  public sealed class SharpSummary : SharpMaterial
  {
    public SharpSummary(string text) {
      Text = text;
    }

    public string Text { get; internal set; }

    //TODO Add param etc.
    //TODO Add auto creation for template xml


    public override void Compile(StringBuilder sb) {
      sb.AppendLine("/// <summary>");
      sb.AppendLine($"/// {Text}");
      sb.AppendLine("/// </summary>");
    }
  }
}