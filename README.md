# SharpBuilder

SharpBuilder is a library for building C# code. It is useful for generating code.

SharpBuilder main purpose is to create C# models from various sources. For example, you can create a model from a database table or a JSON schema. However the read and export must be done manually.

SharpBuilder is not a code generator. It does not generate code for you. It only helps you to build valid C# code.

## Installation
 
SharpBuilder is available on [NuGet](https://www.nuget.org/packages/SharpBuilder/).

## Use cases
- Creating models from excel files.
- Creating models from database tables.
- Creating models from JSON schemas.
- Creating models from XML schemas.
- Creating models from CSV files.

Be aware that SharpBuilder does not read files. You must read the files yourself and then use SharpBuilder to create the models.


## Todo

- [ ] Add support for `SharpClass`, `SharpStruct`, `SharpEnum` and more 
- [ ] Validation before compiling class to text

### Builders

#### SharpAttributeBuilder
```csharp
var attribute = new SharpAttributeBuilder("Obsolete")
    .AddParameter("This is obsolete")
    .Build();
```

#### SharpClassBuilder
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
```csharp
var constant = new SharpConstantBuilder("Name", typeof(string), "John Doe")
    .Build();
```

#### SharpFieldBuilder
```csharp
var field = new SharpFieldBuilder("Name", typeof(string))
    .Build();
```

#### SharpPropertyBuilder
```csharp
var property = new SharpPropertyBuilder("Name", typeof(string))
    .Static()
    .Build();
```
~~~~



