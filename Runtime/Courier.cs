namespace CourierEventSystem.Runtime
{
    /// <summary>
    /// Main Courier class. Contains static methods to register and send events.
    /// </summary>
    public sealed class Courier
    {
        private static CourierEventManager _instance;

        private Courier()
        {
        }

        private static CourierEventManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CourierEventManager();
                }
                return _instance;
            }
        }

        public static void Register<T>(CourierEventListener handler) where T : CourierEventBase
        {
            Instance.Register<T>(handler);
        }

        public static void Unregister<T>(CourierEventListener handler) where T : CourierEventBase
        {
            Instance.Unregister<T>(handler);
        }

        public static void Send<T>(T evt) where T : CourierEventBase
        {
            Instance.Send(evt);
        }

        public static void Send<T>() where T : CourierEventBase, new()
        {
            Instance.Send(new T());
        }

    }
}