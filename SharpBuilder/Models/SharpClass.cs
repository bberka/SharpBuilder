using SharpBuilder.Enums;

namespace SharpBuilder.Models;

public class SharpClass
{
  internal SharpClass() {
    
  }
  public List<string> UsingList { get; internal set; } = new();
  public string NameSpace { get; internal set; }
  public string Name { get; internal set; }
  public List<SharpProperty> Properties { get; internal set; } = new();
  public List<SharpField> Fields { get; internal set; } = new();
  public List<SharpConstant> Constants { get; internal set; } = new();
  public AccessModifier AccessModifier { get; internal set; }
  public Keyword Keyword { get; internal set; }

  //public void Export(string fileNameWithoutExtension) {
  //  SharpExtensions.Export(this, fileNameWithoutExtension);
  //}
}