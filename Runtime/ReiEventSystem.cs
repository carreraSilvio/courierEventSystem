namespace ReiEvents.Runtime
{
    public sealed class ReiEventSystem
    {
        private static ReiEventManager _instance;

        private ReiEventSystem()
        {
        }

        private static ReiEventManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ReiEventManager();
                }
                return _instance;
            }
        }

        public static void AddHandler<T>(ReiEventHandler handler) where T : ReiEventBase
        {
            Instance.AddHandler<T>(handler);
        }

        public static void RemoveHandler<T>(ReiEventHandler handler) where T : ReiEventBase
        {
            Instance.RemoveHandler<T>(handler);
        }

        public static void Invoke<T>(T evt) where T : ReiEventBase
        {
            Instance.Invoke(evt);
        }

    }
}