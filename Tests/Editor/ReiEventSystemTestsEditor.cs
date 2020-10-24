using NUnit.Framework;
using ReiEvents.Runtime;

namespace ReiEvents.Tests.Editor
{
    public class TestInvoke
    {
        [Test]
        public void WhenInvokeEventWithNoHandlers_DontThrowAnException()
        {
            //Arrange & Act & Assert
            Assert.DoesNotThrow(() => Rei.Invoke(new ReiEvent()));
        }

        [Test]
        public void WhenInvokeEventWithHandler_CallHandlerMethod()
        {
            bool called = false;
            void HandlerSample(ReiEventBase reiEvent)
            {
                called = true;
            }

            //Arrange
            Rei.AddHandler<ReiEvent>(HandlerSample);

            //Act
            Rei.Invoke(new ReiEvent());

            //Assert
            Assert.IsTrue(called);
        }

        [Test]
        public void WhenInvokeMultipleEventsWithHandler_CallHandlerMethod()
        {
            bool calledBegin = false;
            bool calledComplete = false;
            void HandleBeginEvent(ReiEventBase reiEvent)
            {
                calledBegin = true;
            }
            void HandleCompleteEvent(ReiEventBase reiEvent)
            {
                calledComplete = true;
            }

            //Arrange
            Rei.AddHandler<BeginEvent>(HandleBeginEvent);
            Rei.AddHandler<CompleteEvent>(HandleCompleteEvent);

            //Act
            Rei.Invoke(new BeginEvent());
            Rei.Invoke(new CompleteEvent());

            //Assert
            Assert.IsTrue(calledBegin && calledComplete);
        }

        [Test]
        public void WhenAddHandlerTwiceAndInvokeEvent_CallHandlerOnce()
        {
            int calledCount = 0;
            void HandleEvent(ReiEventBase reiEvent)
            {
                calledCount++;
            }

            //Arrange
            Rei.AddHandler<ReiEvent>(HandleEvent);
            Rei.AddHandler<ReiEvent>(HandleEvent);

            //Act
            Rei.Invoke<ReiEvent>(new ReiEvent());

            //Assert
            Assert.IsTrue(calledCount == 1);
        }
    }
}