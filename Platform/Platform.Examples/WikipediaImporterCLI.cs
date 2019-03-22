﻿using System;
using System.IO;
using Platform.Data.Core.Doublets;
using Platform.Data.Core.Sequences;
using Platform.Helpers;

namespace Platform.Examples
{
    public class WikipediaImporterCLI : ICommandLineInterface
    {
        public void Run(params string[] args)
        {
            var linksFile = ConsoleHelpers.GetOrReadArgument(0, "Links file", args);
            var wikipediaFile = ConsoleHelpers.GetOrReadArgument(1, "Wikipedia xml file", args);

            if (!File.Exists(linksFile))
                Console.WriteLine("Entered links file does not exists.");
            else if (!File.Exists(wikipediaFile))
                Console.WriteLine("Entered wikipedia xml file does not exists.");
            else
            {
                var cancellationSource = ConsoleHelpers.HandleCancellation();

                const long gb32 = 34359738368;

                using (var memoryManager = new UInt64LinksMemoryManager(linksFile, gb32))
                using (var links = new UInt64Links(memoryManager))
                {
                    var syncLinks = new SynchronizedLinks<ulong>(links);
                    UnicodeMap.InitNew(links);
                    var sequences = new Sequences(syncLinks, new SequencesOptions { UseCompression = true });
                    var wikipediaStorage = new WikipediaLinksStorage(sequences);
                    var wikipediaImporter = new WikipediaImporter(wikipediaStorage);

                    wikipediaImporter.Import(wikipediaFile, cancellationSource.Token).Wait();
                }
            }

            ConsoleHelpers.PressAnyKeyToContinue();
        }
    }
}
