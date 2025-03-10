namespace SharpBuilder.Internal
{
  internal static class StringHelper
  {
    public static string EscapeSharpString(string value) {
      return value
             .Replace("\\", @"\\")
             .Replace("\"", "\\\"")
             .Replace("\r", @"\r")
             .Replace("\n", @"\n")
             .Replace("\t", @"\t")
             .Replace("\b", @"\b")
             .Replace("\f", @"\f")
             .Replace("\v", @"\v")
             .Replace("\a", @"\a")
             .Replace("\0", @"\0")
        ;
    }
  }
}