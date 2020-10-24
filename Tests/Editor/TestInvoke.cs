using NUnit.Framework;
using CourierEventSystem.Runtime;

namespace CourierEventSystem.Tests.Editor
{
    public class TestInvoke
    {
        [Test]
        public void WhenInvokeEventWithNoHandlers_DontThrowAnException()
        {
            //Arrange & Act & Assert
            Assert.DoesNotThrow(() => Courier.Send(new CourierEvent()));
        }

        [Test]
        public void WhenInvokeEventWithHandler_CallHandlerMethod()
        {
            bool called = false;
            void HandlerSample(CourierEventBase reiEvent)
            {
                called = true;
            }

            //Arrange
            Courier.Register<CourierEvent>(HandlerSample);

            //Act
            Courier.Send(new CourierEvent());

            //Assert
            Assert.IsTrue(called);
        }

        [Test]
        public void WhenInvokeMultipleEventsWithHandler_CallHandlerMethod()
        {
            bool calledBegin = false;
            bool calledComplete = false;
            void HandleBeginEvent(CourierEventBase reiEvent)
            {
                calledBegin = true;
            }
            void HandleCompleteEvent(CourierEventBase reiEvent)
            {
                calledComplete = true;
            }

            //Arrange
            Courier.Register<BeginEvent>(HandleBeginEvent);
            Courier.Register<CompleteEvent>(HandleCompleteEvent);

            //Act
            Courier.Send(new BeginEvent());
            Courier.Send(new CompleteEvent());

            //Assert
            Assert.IsTrue(calledBegin && calledComplete);
        }

        [Test]
        public void WhenAddHandlerTwiceAndInvokeEvent_CallHandlerOnce()
        {
            int calledCount = 0;
            void HandleEvent(CourierEventBase reiEvent)
            {
                calledCount++;
            }

            //Arrange
            Courier.Register<CourierEvent>(HandleEvent);
            Courier.Register<CourierEvent>(HandleEvent);

            //Act
            Courier.Send<CourierEvent>();

            //Assert
            Assert.IsTrue(calledCount == 1);
        }
    }
}