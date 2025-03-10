# SharpBuilder

SharpBuilder is a library for building valid C# code. It is useful for generating working code.

SharpBuilder main purpose is to create C# models from various sources. For example, you can create a model from a
Database Table or a JSON schema. However, the read and export must be done manually.

SharpBuilder is not a code generator. It does not generate code for you. It only helps you to build valid C# code.

## Installation

SharpBuilder is available on [NuGet](https://www.nuget.org/packages/SharpBuilder/).

## Use cases

- Creating models from Excel files.
- Creating models from Database tables.
- Creating models from JSON schemas.
- Creating models from XML schemas.
- Creating models from CSV files.

Be aware that SharpBuilder does not read files. You must read the files yourself and then use SharpBuilder to create the
models.

### Builders

#### SharpAttributeBuilder

- SharpAttribute can be added to almost everything except SharpFile and itself

```csharp
var attribute = new SharpAttributeBuilder("Obsolete")
    .AddParameter("This is obsolete")
    .Build();
```

#### SharpClassBuilder

- SharpClassBuilder can be added to SharpFile

```csharp
var @class = new SharpClassBuilder("Person")
    .AddAttribute(new SharpAttributeBuilder("Obsolete")
        .AddParameter("This is obsolete")
        .Build())
    .AddProperty(new SharpPropertyBuilder("Name", typeof(string))
        .AddAttribute(new SharpAttributeBuilder("Required")
            .Build())
        .Build())
    .AddProperty(new SharpPropertyBuilder("Age", typeof(int))
        .AddAttribute(new SharpAttributeBuilder("Required")
            .Build())
        .Build())
    .Build();
```

#### SharpConstantBuilder

- SharpConstant can be added to SharpClass

```csharp
var constant = new SharpConstantBuilder("Name", typeof(string), "John Doe")
    .Build();
```

#### SharpFieldBuilder

- SharpField can be added to SharpClass

```csharp
var field = new SharpFieldBuilder("Name", typeof(string))
    .Build();
```

#### SharpPropertyBuilder

- SharpProperty can be added to SharpClass

```csharp
var property = new SharpPropertyBuilder("Name", typeof(string))
    .Static()
    .Build();
```

#### SharpEnumKeyBuilder

- SharpEnumKey can be added to SharpEnum

```csharp
var exampleEnumKey = new SharpEnumKeyBuilder("Name")
    .WithValue(23) //Sets an integer value
    .ClearValue() //Clears set value, does nothing if value is not set before
    .Build();
```

#### SharpEnumBuilder

- Ability to change Enum value type to any other value other than is not recommended by Microsoft.
  Thats why that option is not provided by the library. If you exceed integer value limit, you may need to rethink what
  you are doing.
- SharpEnum can be added to SharpFile or SharpClass

```csharp
var exampleEnum = new SharpEnumBuilder("Name")
    .AddKey(exampleEnumKey) //Single key 
    .RemoveKey(exampleKey) //Remove a key instance
    .AddKeys([exampleEnumKey]) //Add list of keys
    .ClearKeys() //Clears list of keys
    .SetKeys([exampleEnumKey]) //Completely overrides existing keys
    .Build();
```

## Todo

- [ ] Add support for `SharpStruct` and more
- [ ] More Validation before compiling class to text
- [ ] Tests

# Changelog

## v4.0

- !Breaking: All library classes is changed to sealed.
- !Breaking: Fixed a bug where AddAttributes method was actually setting the whole list instead of calling AddRange
- Added support for multiple .NET versions.
- Added null value checks in constructors will only be triggered when *Builder.Build() is called.
- SharpClass now has Classes property which can be used to create inner classes.
- Added SharpEnum which can be added to SharFile or SharpClass.
- Added SharpEnumKey which can be added inside SharpEnum.
- Added internal abstract class and interface to reduce copy paste code.
- After build is called, no other builder methods can be called
- Added option to add attributes to some other builders
- Simple tests project has been removed, in future might add unit tests

## v3.0 and before

- Implemented SharpClassBuilder
- Implemented SharpAttributeBuilder
- Implemented SharpConstantBuilder
- Implemented SharpFieldBuilder
- Implemented SharpFileBuilder
- Implemented SharpPropertyBuilder
- Implemented SharpSummaryBuilder
