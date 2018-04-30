using Domain.Events;
using FluentNHibernate.Mapping;

namespace Persistent.NHibernate.Map
{
    public class LoggedEventMap : ClassMap<LoggedEvent>
    {
        public LoggedEventMap()
        {
            Id(x => x.Id).Column("EventId");

            Map(x => x.EventOperationCode);
            Map(x => x.AggregateId);
            Map(x => x.TimeStamp);
            Map(x => x.Data).Length(4000);
        }
    }
}
