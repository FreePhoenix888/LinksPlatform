﻿using Platform.Data.Doublets;
using Platform.Data.Doublets.Sequences;

namespace Platform.Examples
{
    public class WikipediaLinksStorage : IWikipediaStorage<ulong>
    {
        private readonly Sequences _sequences;
        private readonly SynchronizedLinks<ulong> _links;
        private ulong _elementMarker;
        private ulong _textElementMarker;
        private ulong _documentMarker;

        public WikipediaLinksStorage(Sequences sequences)
        {
            _sequences = sequences;
            _links = sequences.Links;
            InitConstants();
        }

        private void InitConstants()
        {
            var markerIndex = UnicodeMap.LastCharLink + 1;
            _elementMarker = CreateConstant(markerIndex++);
            _textElementMarker = CreateConstant(markerIndex++);
            // Reserve 100 more
            _documentMarker = CreateConstant(markerIndex++);
            for (var i = 0; i < 99; i++)
            {
                CreateConstant(markerIndex++);
            }
        }

        private ulong CreateConstant(ulong markerIndex)
        {
            if (!_links.Exists(markerIndex))
            {
                _links.Create();
            }
            return markerIndex;
        }

        public ulong CreateDocument(string name) => Create(_documentMarker, name);

        public ulong CreateElement(string name) => Create(_elementMarker, name);

        public ulong CreateTextElement(string content) => Create(_textElementMarker, content);

        private ulong Create(ulong marker, string content)
        {
            var contentSequence = CreateSequence1(content);
            return _links.CreateAndUpdate(marker, contentSequence);
        }

        private ulong CreateSequence0(string @string)
        {
            var contentLinks = UnicodeMap.FromStringToLinkArray(@string);
            var contentSequence = _sequences.Create(contentLinks);
            return contentSequence;
        }

        private ulong CreateSequence1(string @string)
        {
            var contentLinksGroups = UnicodeMap.FromStringToLinkArrayGroups(@string);
            var contentSequence = _sequences.Create(contentLinksGroups);
            return contentSequence;
        }

        public void AttachElementToParent(ulong elementToAttach, ulong parent) => _links.CreateAndUpdate(parent, elementToAttach);
    }
}

