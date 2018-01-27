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

            _mockedSubscriber.Setup(sub => sub.Update()).Verifiable();

            _sudWheaterStation.NotifySubscribers();

            _mockedSubscriber.Verify(sub => sub.Update(), Times.AtLeastOnce);
        }

        private List<IDisplayObserver> GetListOfSubscribers()
        {

            var sub1 = new Mock<IDisplayObserver>();
            var sub2 = new Mock<IDisplayObserver>();
            var sub3 = new Mock<IDisplayObserver>();

            return new List<IDisplayObserver> {

                sub1.Object,
                sub2.Object,
                sub3.Object
            };
        }

        private void InsertNotifiers() {

            _allSubscriberStub.ForEach(sub => _sudWheaterStation.AddSubscriber(sub)); ;

        }
    }


}
