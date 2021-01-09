[![Build status](https://travis-ci.org/Konard/LinksPlatform.svg?branch=master "Build status")](https://travis-ci.org/Konard/LinksPlatform)

# LinksPlatform ([русская версия](https://github.com/Konard/LinksPlatform/blob/master/README.ru.md))

The Links Platform is a modular framework, which includes two DBMS implementations based on [the associative data model](https://en.wikipedia.org/wiki/Associative_model_of_data): [Doublets](https://github.com/linksplatform/Data.Doublets) и [Triplets](https://github.com/linksplatform/Data.Triplets); as well as translators between programming languages (for example [from C# to C++](https://github.com/linksplatform/RegularExpressions.Transformer.CSharpToCpp)).

Most of the libraries included in this framework can be used separately if necessary and are located [on the Links Platform organization page](https://github.com/linksplatform). Implementations in C# are available for all libraries, in the near future they will also be available in С++ (translation is currently underway).

[Documentation](http://linksplatform.github.io/Documentation)

[![introduction](https://raw.githubusercontent.com/LinksPlatform/Documentation/master/doc/Intro/intro-animation-500.gif "introduction")](https://github.com/Konard/LinksPlatform/wiki/How-it-all-began)

[Graphical introduction](https://github.com/Konard/LinksPlatform/wiki/How-it-all-began)

## [Quick start example](https://github.com/linksplatform/HelloWorld.Doublets.DotNet)

```C#
using System;
using Platform.Data;
using Platform.Data.Doublets;
using Platform.Data.Doublets.Memory.United.Generic;

namespace HelloWorld.Doublets.DotNet
{
    class Program
    {
        static void Main()
        {
            using (var links = new UnitedMemoryLinks<uint>("db.links"))
            {
                var link = links.Create();
                link = links.Update(link, link, link);
                Console.WriteLine("Hello World!");
                Console.WriteLine($"This is my first link: {links.Format(link)}");
                Console.WriteLine($"Total links in the storage: {links.Count()}.");
                link = links.Update(link, default, default);
                links.Delete(link);
            }
        }
    }
}
```

## [SQLite vs Doublets](https://github.com/linksplatform/Comparisons.SQLiteVSDoublets)

[![Image with result of performance comparison between SQLite and Doublets.](https://raw.githubusercontent.com/linksplatform/Documentation/master/doc/Examples/sqlite_vs_doublets_performance.png "Result of performance comparison between SQLite and Doublets")](https://github.com/linksplatform/Comparisons.SQLiteVSDoublets)

## Description

Inspired by the work of Simon Williams ([The Associative Model of Data](https://en.wikipedia.org/w/index.php?title=Associative_model_of_data&oldid=913469847)), [book](https://web.archive.org/web/20181219134621/http://sentences.com/docs/amd.pdf), [whitepaper](http://iacis.org/iis/2009/P2009_1301.pdf).

Comparison of models:

![Comparison of models](https://github.com/LinksPlatform/Documentation/raw/master/doc/ModelsComparison/relational_model_vs_associative_model_vs_links.png)

Comparison of theories:

![Comparison of theories](https://github.com/LinksPlatform/Documentation/raw/master/doc/TheoriesComparison/theories_comparison_en.png)

This platform uses a unified data type — link, which is a combination of Item and Link from a work by Simon Williams. So the Item or [Point](https://en.wikipedia.org/wiki/Point) is a specific case of the [link, which references itself](http://linksplatform.github.io/itself.html).

There are two variants of Link structure:

> <img src="https://raw.githubusercontent.com/LinksPlatform/Documentation/master/doc/ST-dots.png" width="400" title="Source-Target link, untyped" alt="Source-Target link, untyped" />
> <img src="https://raw.githubusercontent.com/LinksPlatform/Documentation/master/doc/doublet-colored.png" width="400" title="Source-Target link, untyped" alt="Source-Target link, untyped" />

- [Untyped](https://en.wikipedia.org/wiki/Type_theory), each link contains [Source](https://en.wikipedia.org/wiki/Source) ([beginning](https://en.wikipedia.org/wiki/Begin), [start](https://en.wikipedia.org/wiki/Start), [first](https://en.wikipedia.org/wiki/First), [left](https://en.wikipedia.org/wiki/Left), [subject](https://en.wikipedia.org/wiki/Subject)) and [Target](https://en.wikipedia.org/wiki/Target) ([ending](https://en.wikipedia.org/wiki/End), [stop](https://en.wikipedia.org/wiki/Stop), [last](https://en.wikipedia.org/wiki/Last_(disambiguation)), [right](https://en.wikipedia.org/wiki/Right_(disambiguation)), [predicate](https://en.wikipedia.org/wiki/Predicate), [object](https://en.wikipedia.org/wiki/Object)).

> <img src="https://raw.githubusercontent.com/LinksPlatform/Documentation/master/doc/SLT-dots.png" width="400" title="Source-Linker-Target link, typed" alt="Source-Linker-Target link, typed" />
> <img src="https://raw.githubusercontent.com/LinksPlatform/Documentation/master/doc/triplet-colored.png" width="400" title="Source-Linker-Target link, typed" alt="Source-Linker-Target link, typed" />

- [Typed](https://en.wikipedia.org/wiki/Type_theory) ([semantic](https://en.wikipedia.org/wiki/Semantics)), with added [Linker](https://en.wikipedia.org/wiki/Linker) ([verb](https://en.wikipedia.org/wiki/Verb), [action](https://en.wikipedia.org/wiki/Action_(philosophy)), [type](https://en.wikipedia.org/wiki/Type_system), [category](https://en.wikipedia.org/wiki/Category_theory), [predicate](https://en.wikipedia.org/wiki/Predicate), [transition](https://en.wikipedia.org/wiki/Transition_system), [algorithm](https://en.wikipedia.org/wiki/Algorithm)), so any additional info about a type of connection between two links can be stored here.

Links Platform planned as a [system](https://en.wikipedia.org/wiki/System_(disambiguation)), that [combines](https://en.wikipedia.org/wiki/Combine) simple [associative memory](https://en.wikipedia.org/wiki/Associative_memory) [storage](https://en.wikipedia.org/wiki/Computer_data_storage) (Links) and [transformation](https://en.wikipedia.org/wiki/Transformation) [execution](https://en.wikipedia.org/wiki/Execution_(computing)) [engine](https://en.wikipedia.org/wiki/Database_engine) (Triggers). There will be an ability to [program](https://en.wikipedia.org/wiki/Program_(machine)) that [system](https://en.wikipedia.org/wiki/System_(disambiguation)) dynamically, due to the fact that all [algorithms](https://en.wikipedia.org/wiki/Algorithm) will be treated as [data](https://en.wikipedia.org/wiki/Data_(disambiguation)) inside the [storage](https://en.wikipedia.org/wiki/Computer_data_storage). Such [algorithms](https://en.wikipedia.org/wiki/Algorithm) can also change themselves in [real-time](https://en.wikipedia.org/wiki/Real-time) based on [input](https://en.wikipedia.org/wiki/Input) from the [environment](https://en.wikipedia.org/wiki/Environment). The Links Platform is a method of modeling the high-level [associative memory](https://en.wikipedia.org/wiki/Associative_memory) effects of [human](https://en.wikipedia.org/wiki/Human) [mind](https://en.wikipedia.org/wiki/Mind).

One of the most important goals of the project is to accelerate the development of automation to the level when automation can be itself automated. In other words, this project should help to implement a bot-programmer which will be able to create programs based on descriptions in human language.

## Road map
[![Road Map, Status](https://raw.githubusercontent.com/LinksPlatform/Documentation/master/doc/RoadMap-status.png "Road Map, Status")](https://github.com/Konard/LinksPlatform/milestones)

[Project status](https://github.com/Konard/LinksPlatform/milestones)

## Swagger Connector Concept

[Links (doublets) API swagger connector.](https://gist.github.com/Konard/c76f9948bb25a0d7aff1)

[Links (triplets, micro RDF) API swagger connector.](https://gist.github.com/Konard/e6a0bff583bbca4d452b)

## [Frequently asked questions](https://github.com/Konard/LinksPlatform/wiki/FAQ)

## Contacts

https://vk.com/linksplatform

https://vk.com/konard

[![Join the chat at https://gitter.im/Konard/LinksPlatform](https://badges.gitter.im/Join%20Chat.svg)](https://gitter.im/Konard/LinksPlatform?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)
