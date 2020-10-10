using NUnit.Framework;
using ReiEvents.Runtime;
using System;
using UnityEngine;

namespace ReiEvents.Tests.Runtime
{
    public class TestInvoke
    {
        [Test]
        public void WhenInvokeEventWithNoHandlers_DontThrowAnException()
        {
            //Arrange & Act & Assert
            Assert.DoesNotThrow(() => ReiEventSystem.Invoke<ReiEvent>(new ReiEvent()));
        }
    }
}