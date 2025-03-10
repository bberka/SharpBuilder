using System.Text;

namespace SharpBuilder.Abstract
{
  public abstract class SharpMaterial : ICompile
  {
    public override string ToString() {
      var sb = new StringBuilder();
      Compile(sb);
      return sb.ToString();
    }

    public abstract void Compile(StringBuilder sb);
  }
}