using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using SharpBuilder.Abstract;

namespace SharpBuilder.Models
{
  public sealed class SharpFile : SharpMaterial
  {
    public SharpFile(string fileName, string nameSpace) {
      FileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);
      Namespace = string.IsNullOrEmpty(nameSpace)
                    ? "SharpBuilder.Models"
                    : nameSpace;
    }

    public List<string> UsingList { get; internal set; } = new List<string>();
    public string FileNameWithoutExtension { get; internal set; }
    public string Namespace { get; internal set; }
    public bool BlockScopedNameSpace { get; internal set; } = false;
    public List<SharpClass> Classes { get; internal set; } = new List<SharpClass>();
    public List<SharpEnum> Enums { get; internal set; } = new List<SharpEnum>();

    public void Export(string outputDirectory) {
      var text = ToString();
      var directory = Path.GetDirectoryName(outputDirectory);
      if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory)) Directory.CreateDirectory(directory);

      var outputFilePath = Path.Combine(outputDirectory, FileNameWithoutExtension);
      File.WriteAllText(outputFilePath, text);
    }


    public override void Compile(StringBuilder sb) {
      if (string.IsNullOrEmpty(FileNameWithoutExtension)) {
        throw new ArgumentNullException(nameof(FileNameWithoutExtension));
      }

      if (string.IsNullOrEmpty(Namespace)) {
        throw new ArgumentNullException(nameof(Namespace));
      }

      if (UsingList.Count > 0) {
        foreach (var item in UsingList) sb.AppendLine("using " + item + ";");
        sb.AppendLine();
      }

      sb.AppendLine("namespace " + Namespace + (BlockScopedNameSpace
                                                  ? "{"
                                                  : ";"));
      sb.AppendLine();


      foreach (var sc in Enums) {
        sc.Compile(sb);
        sb.AppendLine();
      }


      foreach (var sc in Classes) {
        sc.Compile(sb);
        sb.AppendLine();
      }


      if (BlockScopedNameSpace) {
        sb.AppendLine("}");
      }
    }
  }
}