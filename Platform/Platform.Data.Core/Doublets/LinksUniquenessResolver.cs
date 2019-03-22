﻿using System.Collections.Generic;

namespace Platform.Data.Core.Doublets
{
    public class LinksUniquenessResolver<T> : LinksDecoratorBase<T>
    {
        public LinksUniquenessResolver(ILinks<T> links) : base(links) {}

        public override T Update(IList<T> restrictions)
        {
            var newLinkAddress = Links.SearchOrDefault(restrictions[Constants.SourcePart], restrictions[Constants.TargetPart]);

            if (Equals(newLinkAddress, default(T)))
                return base.Update(restrictions);

            return ResolveAddressChangeConflict(restrictions[Constants.IndexPart], newLinkAddress);
        }

        protected virtual T ResolveAddressChangeConflict(T oldLinkAddress, T newLinkAddress)
        {
            if (Links.Exists(oldLinkAddress))
                Delete(oldLinkAddress);

            return newLinkAddress;
        }
    }
}
