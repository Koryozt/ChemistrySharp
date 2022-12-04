
# ChemistrySharp
![cslogo](https://user-images.githubusercontent.com/93677342/205516309-2aa200b6-b266-48b1-85e1-0e75463e4eaa.png)
- - -

# About

ChemistrySharp is a C# library designed to work in an easy way with the PubChem PUG REST Service which allows you to get all the chemistry information available.
This library gives you the following features:

- Get information of any assay, atom, bond, substance or compound with just one line of code.
- Obtain more information using the Getter.cs class which has several methods to get the exact information you're looking for.
- Easy to use.
- Clever code and implemented with the latest technologies.

This was made by my person but if you want to contribute to improve something or add a new functionality do it!

# Installation

### GIT
``` 
git clone https://github.com/Koryozt/ChemistrySharp 
```

### Nuget
```
dotnet add package ChemistrySharp --version 1.3.5 
```
# Usage

ChemistrySharp is easy to use, let's see a few examples.

```cs
// This is an example of how to get a compound in the easiest way.
namespace Demo
{
    class Program
    {
        public static void Main()
        {
            Compound compound = await Compound.FromCompoundIdentifier(2244);
            Console.WriteLine(compound);
        }
    }
}
```
- - -
```cs
// Largest but more specific way to get information.
namespace Demo
{
    class Program
    {
        public static void Main()
        {
            Getters getter = new Getters();
            JObject record = await getter.Get(2244, Namespaces.cid, Domain.compound, null, Output.JSON, null);
            Compound compound = new Compound(record);
            Console.WriteLine(compound);
        }
    }
}
```

# License

Copyright © 2022 Gustavo Silva. All rights reserved.

Licensed under the MIT license.
