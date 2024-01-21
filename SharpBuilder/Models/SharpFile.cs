using System.Text;

namespace SharpBuilder.Models;

public class SharpFile
{
  public SharpFile(string fileNameWithoutExtension, string ns) {
    FileNameWithoutExtension = fileNameWithoutExtension;
    Namespace = string.IsNullOrEmpty(ns)
                  ? "SharpBuilder.Models"
                  : ns;
  }

  public List<string> UsingList { get; internal set; } = new();
  public string FileNameWithoutExtension { get; internal set; }
  public string Namespace { get; internal set; }
  public bool BlockScopedNameSpace { get; internal set; } = false;
  public List<SharpClass> Classes { get; internal set; } = new();

  public void Export(string outputDirectory) {
    var text = ToString();
    var directory = Path.GetDirectoryName(outputDirectory);
    if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory)) Directory.CreateDirectory(directory);

    var outputFilePath = Path.Combine(outputDirectory, FileNameWithoutExtension);
    File.WriteAllText(outputFilePath, text);
  }

  public override string ToString() {
    var sb = new StringBuilder();
    Compile(sb);
    return sb.ToString();
  }


  public void Compile(StringBuilder sb) {
    foreach (var item in UsingList) sb.AppendLine("using " + item + ";");

    sb.AppendLine();
    sb.AppendLine("namespace " + Namespace);
    if (BlockScopedNameSpace) sb.AppendLine("{");
    else sb.Append(';');

    sb.AppendLine();


    foreach (var sc in Classes) {
      sc.Compile(sb);
      sb.AppendLine();
    }


    if (BlockScopedNameSpace) {
      sb.AppendLine("");
      sb.AppendLine("}");
    }
  }
}