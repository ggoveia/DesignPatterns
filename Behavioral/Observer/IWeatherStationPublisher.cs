using System;
using System.Collections.Generic;
using System.Text;

namespace Behavioral.Observer
{
    public interface ISubject
    {
        void AddSubscriber(IDisplayObserver subscriber);

        void RemoveSubscriber(int subscriber);

        void NotifySubscribers();

        List<IDisplayObserver> GetAllSubscribers();
    }
}
