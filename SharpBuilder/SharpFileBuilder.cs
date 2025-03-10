using System;
using System.Collections.Generic;
using System.IO;
using SharpBuilder.Abstract;
using SharpBuilder.Models;

namespace SharpBuilder
{
  public sealed class SharpFileBuilder : SharpMaterialBuilder
  {
    private readonly SharpFile _file;

    public SharpFileBuilder(string fileName, string nameSpace) {
      _file = new SharpFile(Path.GetFileNameWithoutExtension(fileName), nameSpace);
    }

    public SharpFileBuilder AddUsing(string usingString) {
      EnsureNotBuilt();
      _file.UsingList.Add(usingString);
      return this;
    }

    public SharpFileBuilder AddUsingList(List<string> list) {
      EnsureNotBuilt();
      _file.UsingList = list;
      return this;
    }

    public SharpFileBuilder AddClass(SharpClass sharpClass) {
      EnsureNotBuilt();
      _file.Classes.Add(sharpClass);
      return this;
    }

    public SharpFileBuilder AddClasses(IEnumerable<SharpClass> sharpClasses) {
      EnsureNotBuilt();
      _file.Classes.AddRange(sharpClasses);
      return this;
    }

    public SharpFileBuilder OverrideNameSpace(string nameSpace) {
      EnsureNotBuilt();
      _file.Namespace = nameSpace;
      return this;
    }

    public SharpFileBuilder OverrideFileName(string fileName) {
      EnsureNotBuilt();
      _file.FileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);
      return this;
    }

    public SharpFileBuilder BlockScopedNameSpace(bool blockScopedNameSpace) {
      EnsureNotBuilt();
      _file.BlockScopedNameSpace = blockScopedNameSpace;
      return this;
    }

    public SharpFile Build() {
      SetBuilt();
      return _file;
    }
  }
}