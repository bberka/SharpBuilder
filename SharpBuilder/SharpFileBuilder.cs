using SharpBuilder.Models;

namespace SharpBuilder;

public class SharpFileBuilder
{
  private readonly SharpFile _file;

  public SharpFileBuilder(string fileNameWithoutExtension, string nameSpace) {
    _file = new SharpFile(fileNameWithoutExtension, nameSpace);
  }

  public SharpFileBuilder WithUsing(string usingString) {
    _file.UsingList.Add(usingString);
    return this;
  }

  public SharpFileBuilder WithUsingList(List<string> list) {
    _file.UsingList = list;
    return this;
  }

  public SharpFileBuilder WithClass(SharpClass sharpClass) {
    _file.Classes.Add(sharpClass);
    return this;
  }

  public SharpFileBuilder WithClasses(IEnumerable<SharpClass> sharpClasses) {
    _file.Classes.AddRange(sharpClasses);
    return this;
  }

  public SharpFileBuilder OverrideNameSpace(string nameSpace) {
    _file.Namespace = nameSpace;
    return this;
  }

  public SharpFileBuilder OverrideFileName(string fileName) {
    _file.FileNameWithoutExtension = fileName;
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