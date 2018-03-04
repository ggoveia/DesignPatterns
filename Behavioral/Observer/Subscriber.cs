using System;
using System.Collections.Generic;
using System.Text;

namespace Behavioral.Observer
{
    public class Subscriber: IDisplayObserver
    {
        private int _id;
        private string _name;
        private float _tempareture;
        public float _humidity;
        public float _pressure;

        public float Humidity { get => _humidity; private set => _humidity = 0; }
        public float Pressure { get => _pressure; private set => _pressure = 0; }
        public float Temperature { get => _tempareture; private set => _tempareture = 0; }
        public int Id { get => _id; }
        public string Name { get => _name; }

        
        private Subscriber(int id, string name)
        {
            _id = id;
            _name = name;
        }

        public static Subscriber SubscriberFactory(int id, string name) => new Subscriber(id, name);

        public void Update()
        {
            Humidity = 1;
            Pressure = 1;
            Temperature = 1;
        }
    }
}
