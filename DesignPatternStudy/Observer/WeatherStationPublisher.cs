using System;
using System.Collections.Generic;
using System.Text;

namespace Behavioral.Observer
{
    public class WeatherStationPublisher : ISubject
    {
        public List<IDisplayObserver> Subscribers { get; private set; }

        public WeatherStationPublisher()
        {

            Subscribers = new List<IDisplayObserver>();

        }

        public void RemoveSubscriber(int id)
        {
            Subscribers.Remove(Subscribers.Find(s => s.Id == id));
        }

        public void AddSubscriber(IDisplayObserver subscriber)
        {
            Subscribers.Add(subscriber);
        }
            
        public void NotifySubscribers()
        {
            Subscribers.ForEach(sub => sub.Update());
        }
        
        public List<IDisplayObserver> GetAllSubscribers()
        {
            return Subscribers;
        }
    }
}
