using Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Messaging
{
    public interface INotifyMq
    {
        void SendLoggedEventMessage(LoggedEvent loggedEvent);
    }
}
