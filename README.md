#LinksPlatform

The original idea by Konstantin Dyachenko (Konard).

Inspired by work of Simon Williams (The Associative Model of Data, http://en.wikipedia.org/w/index.php?title=Associative_model_of_data&oldid=417122527).

This platform uses unified data type - link, which is a combination of Item and Link from a work by Simon Williams.

There also at least two variants of Link structure:

> ![Source-Target link, untyped](https://raw.githubusercontent.com/Konard/LinksPlatform/master/doc/ST.png "Source-Target link, untyped")

- Untyped, the simplest yet, each link contains only Source (Beginning) and Target (Ending).

> ![Source-Linker-Target link, typed](https://raw.githubusercontent.com/Konard/LinksPlatform/master/doc/SLT.png "Source-Linker-Target link, typed")

- Typed, with added Linker (Verb, Type) definition, so any additional info about type of connection between two links can be stored here.


Links Platform is a system, that combine simple database (Links) and execution engine (Triggers). So it is provide ability to program that system in any way, due to fact that all algorithms are data inside this database. Idea behind Links Platform is a model of associative memory of human mind. So it is actually copy most of it advantages and disadvantages.
