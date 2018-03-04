using Behavioral.Observer;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace BehavioralTests
{

    public class ObserverTests
    {
        WeatherStationPublisher _sudWheaterStation;
        List<IDisplayObserver> _allSubscriberStub;

        Mock<IDisplayObserver> _mockedSubscriber;

        Mock<IDisplayObserver> _mockedsub1;
        Mock<IDisplayObserver> _mockedsub2;
        Mock<IDisplayObserver> _mockedsub3;
        

        public ObserverTests()
        {

            _sudWheaterStation = new WeatherStationPublisher();
            _allSubscriberStub = GetListOfSubscribers();

            _mockedSubscriber = new Mock<IDisplayObserver>();

        }

        [Fact]
        public void CanIncludeASubscriber()
        {

            var newSubscriber = Subscriber.SubscriberFactory(4, "NewCellphone");
            _sudWheaterStation.AddSubscriber(newSubscriber);

            var allSubscribers = _sudWheaterStation.GetAllSubscribers();

            Assert.Contains<IDisplayObserver>(newSubscriber, allSubscribers);

        }

        [Fact]
        public void CanRemoveASubscriber()
        {
            _sudWheaterStation.RemoveSubscriber(2);

            var allSubscribers = _sudWheaterStation.GetAllSubscribers();

            Assert.False(allSubscribers.Exists(sub => sub.Id == 2));
        }

        [Fact]
        public void CanReturnAllSubscribers()
        {

            var allSubscribers = _sudWheaterStation.GetAllSubscribers();

            allSubscribers.ForEach(sub => Assert.Contains<IDisplayObserver>(sub, _allSubscriberStub));

        }


        [Fact]
        public void ShouldNotifyAllSubscribers()
        {
            InsertNotifiers();

            _mockedsub1.Setup(sub => sub.Update()).Verifiable();
            _mockedsub2.Setup(sub => sub.Update()).Verifiable();
            _mockedsub3.Setup(sub => sub.Update()).Verifiable();
            
            _sudWheaterStation.NotifySubscribers();

            _mockedsub1.Verify(sub => sub.Update());
            _mockedsub2.Verify(sub => sub.Update());
            _mockedsub3.Verify(sub => sub.Update());
        }

        private List<IDisplayObserver> GetListOfSubscribers()
        {
            _mockedsub1 = new Mock<IDisplayObserver>();
            _mockedsub2 = new Mock<IDisplayObserver>();
            _mockedsub3 = new Mock<IDisplayObserver>();

            return new List<IDisplayObserver> {

                _mockedsub1.Object,
                _mockedsub2.Object,
                _mockedsub3.Object
            };
        }

        private void InsertNotifiers() {

            _allSubscriberStub.ForEach(sub => _sudWheaterStation.AddSubscriber(sub)); ;

        }
        
    }


}
