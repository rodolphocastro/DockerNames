# DockerNames

_DockerNames_ 🐋 is a port for [Moby's name generation](https://github.com/moby/moby/blob/master/pkg/namesgenerator/names-generator.go) written in C# and available to the .NET platform.

## 💭 Inspiration

This project is inspired by the awesome folks at [moby/moby](https://github.com/moby/moby) and their idea to pay homage to great scientists and "hackers" when creating names for running containers.

## 📦 Usage

Simply add the `DockerNames` nuget to your project and use the builtin `DockerNameFactory.Instance` to grab a static instance of the Factory!

Then call either the `Element` property or the `Build(char separator = '_')` method to generate a new name.

```csharp
var myFactory = DockerNameFactory.Instance;

var firstName = myFactory.Element;  // Using the shorthand Property
var secondName = myFactory.Build(); // Calling the build method
var thirdName = myFactory.Build(' '); // Calling a build method with a custom separator!
```

There's a sample available at the `samples` folder within this project, check it out 😊

## ⚙ Expanding

Simply inherit the `NameFactoryBase` and call it's `constructor` with two _enumerables_. One for the _left side_ of the names and one for the _right side_ of the names. Most of its methods are extensible!