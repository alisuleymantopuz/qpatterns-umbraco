﻿using System.Collections.Generic;

namespace qPatterns.Core.Domain.Events
{
    public interface IDomainEventHandlerFactory
    {
        IEnumerable<IDomainEventHandler<T>> GetDomainEventHandlersFor<T>(T domainEvent) where T : IDomainEvent;
    }
}
