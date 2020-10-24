using System;
using System.Collections.Generic;

namespace CourierEventSystem.Runtime
{
    public delegate void CourierEventListener(CourierEventBase evt);

    internal sealed class CourierEventManager
    {
        private readonly Dictionary<Type, List<CourierEventListener>> _eventDictionary;

        internal CourierEventManager()
        {
            _eventDictionary = new Dictionary<Type, List<CourierEventListener>>();
        }

        internal void Register<T>(CourierEventListener handler) where T : CourierEventBase
        {
            if (_eventDictionary.TryGetValue(typeof(T), out List<CourierEventListener> handlerList))
            {
                if (!handlerList.Contains(handler))
                {
                    handlerList.Add(handler);
                }
            }
            else
            {
                List<CourierEventListener> newHandlerList = new List<CourierEventListener>
                {
                    handler
                };
                _eventDictionary.Add(typeof(T), newHandlerList);
            }
        }

        internal void Unregister<T>(CourierEventListener handler) where T : CourierEventBase
        {
            if (_eventDictionary.TryGetValue(typeof(T), out List<CourierEventListener> handlerList))
            {
                handlerList.Remove(handler);
            }
        }

        internal void Send<T>(T evt) where T : CourierEventBase
        {
            if (_eventDictionary.TryGetValue(typeof(T), out List<CourierEventListener> handlerList))
            {
                foreach (CourierEventListener handler in handlerList)
                {
                    handler?.Invoke(evt);
                }
            }
        }
    }
}