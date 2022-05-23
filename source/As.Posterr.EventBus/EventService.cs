using As.Posterr.Domain;
using As.Posterr.Domain.Events;
using FluentMediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace As.Posterr.EventPublisher
{
    public class EventService : IEventService
    {
        private readonly IMediator _mediator;

        public List<DomainEvent> Events { get; set; } = new List<DomainEvent>();

        public EventService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Publish()
        {
            await Task.Run(() =>
            {
                var orderedEvents = Events.OrderBy(d => d.CreatedDate.Ticks);
                foreach (var domainEvent in orderedEvents)
                {
                    this._mediator.PublishAsync(domainEvent);
                }
            });
        }
    }
}
