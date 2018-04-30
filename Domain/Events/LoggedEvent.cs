using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Events
{
    public class LoggedEvent : AggregateRoot
    {        
        public virtual string EventOperationCode { get;}
        public virtual int AggregateId { get;}
        public virtual string Data { get;}
        public virtual DateTime? TimeStamp { get;}

        protected LoggedEvent()
        {
        }

        public LoggedEvent(string eventOperationCode, int aggregateId, string data, DateTime? timeStamp)
        {
            EventOperationCode = eventOperationCode ?? throw new ArgumentNullException(nameof(eventOperationCode));
            AggregateId = aggregateId;
            Data = data ?? throw new ArgumentNullException(nameof(data));
            TimeStamp = timeStamp ?? throw new ArgumentNullException(nameof(timeStamp));
        }
    }
}
