using System;
using System.Collections.Generic;

namespace ReiEvents.Runtime
{
    public delegate void ReiEventHandler(ReiEventBase evt);

    internal sealed class ReiEventManager
    {
        private readonly Dictionary<Type, List<ReiEventHandler>> _eventDictionary;

        internal ReiEventManager()
        {
            _eventDictionary = new Dictionary<Type, List<ReiEventHandler>>();
        }

        internal void AddHandler<T>(ReiEventHandler handler) where T : ReiEventBase
        {
            if (_eventDictionary.TryGetValue(typeof(T), out List<ReiEventHandler> handlerList))
            {
                handlerList.Add(handler);
            }
            else
            {
                List<ReiEventHandler> newHandlerList = new List<ReiEventHandler>();
                newHandlerList.Add(handler);
                _eventDictionary.Add(typeof(T), newHandlerList);
            }
        }

        internal void RemoveHandler<T>(ReiEventHandler handler) where T : ReiEventBase
        {
            if (_eventDictionary.TryGetValue(typeof(T), out List<ReiEventHandler> handlerList))
            {
                handlerList.Remove(handler);
            }
        }

        internal void Invoke<T>(T evt) where T : ReiEventBase
        {
            if (_eventDictionary.TryGetValue(typeof(T), out List<ReiEventHandler> handlerList))
            {
                foreach (ReiEventHandler handler in handlerList)
                {
                    handler?.Invoke(evt);
                }
            }
        }
    }
}