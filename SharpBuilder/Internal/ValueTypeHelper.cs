using System;
using System.Globalization;

namespace SharpBuilder.Internal
{
  internal static class ValueTypeHelper
  {
    public static string GetValueTypeName(Type type) {
      return type.Name.ToString();
    }
  }
}