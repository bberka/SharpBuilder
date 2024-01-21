namespace SharpBuilder.Internal;

internal static class ValueTypeHelper
{
  public static string GetValueTypeName(Type type) {
    if (type == typeof(int))
      return "int";
    if (type == typeof(long))
      return "long";
    if (type == typeof(short))
      return "short";
    if (type == typeof(byte))
      return "byte";
    if (type == typeof(bool))
      return "bool";
    if (type == typeof(char))
      return "char";
    if (type == typeof(float))
      return "float";
    if (type == typeof(double))
      return "double";
    if (type == typeof(decimal))
      return "decimal";
    if (type == typeof(object))
      return "object";
    if (type == typeof(sbyte))
      return "sbyte";
    if (type == typeof(uint))
      return "uint";
    if (type == typeof(ulong))
      return "ulong";
    if (type == typeof(ushort))
      return "ushort";
    return "string";
  }
}