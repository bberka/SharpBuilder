
using SharpBuilder;
using SharpBuilder.Enums;

var property = new SharpPropertyBuilder()
  .WithName("Id")
  .WithValueType(typeof(int))
  .Static()
  .WithSetterAccessModifier(AccessModifier.Public)
  .WithGetterAccessModifier(AccessModifier.Public)
  .WithAccessModifier(AccessModifier.Public)
  .Build();

var constant = new SharpConstantBuilder()
  .WithName("TESTCONST")
  .WithValueType(typeof(int))
  .WithValue(1)
  .WithAccessModifier(AccessModifier.Public)
  .Build();

var field = new SharpFieldBuilder()
  .WithName("_id")
  .WithValueType(typeof(int))
  .WithAccessModifier(AccessModifier.Private)
  .Build();

var field2 = new SharpFieldBuilder()
  .WithName("_myName")
  .WithValueType(typeof(int))
  .Static()
  .Readonly()
  .WithAccessModifier(AccessModifier.Internal)
  .Build();

var sharpClass = new SharpClassBuilder()
  .WithNameSpace("SharpBuilder.Test")
  .WithConstant(constant)
  .WithField(field)
  .WithField(field2)
  .WithProperty(property)
  .WithKeyword(Keyword.Static)
  .WithAccessModifier(AccessModifier.Internal)
  .WithUsing("System")
  .WithUsing("System.Collections.Generic")
  .WithName("SharpClassTesting")
  .Build();

sharpClass.Export("exported");
