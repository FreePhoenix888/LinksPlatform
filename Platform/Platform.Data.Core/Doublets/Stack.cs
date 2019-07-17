﻿using System.Collections.Generic;
using Platform.Collections.Stacks;

namespace Platform.Data.Core.Doublets
{
    public class Stack<TLink> : IStack<TLink>
    {
        private static readonly EqualityComparer<TLink> EqualityComparer = EqualityComparer<TLink>.Default;

        private readonly ILinks<TLink> _links;
        private readonly TLink _stack;

        public Stack(ILinks<TLink> links, TLink stack)
        {
            _links = links;
            _stack = stack;
        }

        private TLink GetStackMarker() => _links.GetSource(_stack);

        private TLink GetTopDoublet() => _links.GetTarget(_stack);

        public TLink Peek() => _links.GetTarget(GetTopDoublet());

        public TLink Pop()
        {
            var element = Peek();
            if (!EqualityComparer.Equals(element, _stack))
            {
                var top = GetTopDoublet();
                var previousTop = _links.GetSource(top);
                _links.Update(_stack, GetStackMarker(), previousTop);
                _links.Delete(top);
            }
            return element;
        }

        public void Push(TLink element) => _links.Update(_stack, GetStackMarker(), _links.GetOrCreate(GetTopDoublet(), element));
    }
}
