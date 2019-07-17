﻿using System.Collections.Generic;
using Platform.Helpers.Collections.Stacks;
using Platform.Data.Core.Doublets;

namespace Platform.Data.Core.Sequences
{
    public class DefaultSequenceAppender<TLink> : LinksOperatorBase<TLink>, ISequenceAppender<TLink>
    {
        private static readonly EqualityComparer<TLink> EqualityComparer = EqualityComparer<TLink>.Default;

        private readonly IStack<TLink> _stack;
        private readonly ISequenceHeightProvider<TLink> _heightProvider;

        public DefaultSequenceAppender(ILinks<TLink> links, IStack<TLink> stack, ISequenceHeightProvider<TLink> heightProvider)
            : base(links)
        {
            _stack = stack;
            _heightProvider = heightProvider;
        }

        public TLink Append(TLink sequence, TLink appendant)
        {
            var cursor = sequence;
            while (!EqualityComparer.Equals(_heightProvider.Get(cursor), default))
            {
                var source = Links.GetSource(cursor);
                var target = Links.GetTarget(cursor);
                if (EqualityComparer.Equals(_heightProvider.Get(source), _heightProvider.Get(target)))
                    break;
                else
                {
                    _stack.Push(source);
                    cursor = target;
                }
            }

            var left = cursor;
            var right = appendant;
            while (!EqualityComparer.Equals(cursor = _stack.Pop(), Links.Constants.Null))
            {
                right = Links.GetOrCreate(left, right);
                left = cursor;
            }
            return Links.GetOrCreate(left, right);
        }
    }
}
