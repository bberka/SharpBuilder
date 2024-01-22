using SharpBuilder.Models;

namespace SharpBuilder;

public class SharpFileBuilder
{
  private readonly SharpFile _file;

  public SharpFileBuilder(string fileName, string nameSpace) {
    _file = new SharpFile(Path.GetFileNameWithoutExtension(fileName), nameSpace);
  }

  public SharpFileBuilder AddUsing(string usingString) {
    _file.UsingList.Add(usingString);
    return this;
  }

  public SharpFileBuilder AddUsingList(List<string> list) {
    _file.UsingList = list;
    return this;
  }

  public SharpFileBuilder AddClass(SharpClass sharpClass) {
    _file.Classes.Add(sharpClass);
    return this;
  }

  public SharpFileBuilder AddClasses(IEnumerable<SharpClass> sharpClasses) {
    _file.Classes.AddRange(sharpClasses);
    return this;
  }

  public SharpFileBuilder OverrideNameSpace(string nameSpace) {
    _file.Namespace = nameSpace;
    return this;
  }

  public SharpFileBuilder OverrideFileName(string fileName) {
    _file.FileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);
    return this;
  }

  public SharpFileBuilder BlockScopedNameSpace(bool blockScopedNameSpace) {
    _file.BlockScopedNameSpace = blockScopedNameSpace;
    return this;
  }

  public SharpFile Build() {
    return _file;
  }
}