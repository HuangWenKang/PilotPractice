using Application.Messaging;
using Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Infrastructure.RabbitMq.Messaging
{
    public class NotifyMqTests
    {
        [Fact]
        public void SendEvent_NewEvent_SaveToMq()
        {
            for (int i = 0; i <= 10000; i++)
            {
                string eventOperationCode = "Update";
                string data = Guid.NewGuid().ToString();
                var loggedEvent = new LoggedEvent(eventOperationCode, i, data, DateTime.Now);
                INotifyMq notifyMq = new NotifyMq();
                notifyMq.SendLoggedEventMessage(loggedEvent);
            }          
        }
    }
}
