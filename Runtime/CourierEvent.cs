namespace CourierEventSystem.Runtime
{
    public enum CourierEventState
    {
        None = 0,
        Begin = 1,
        Complete = 2,
        Progress = 3
    }

    public class CourierEvent : CourierEventBase
    {
        public string name;
        public CourierEventState state;

        public CourierEvent()
        {

        }

        public CourierEvent(string name)
        {
            this.name = name;
        }
    }

    public class BeginEvent : CourierEvent
    {
        public BeginEvent()
        {
            state = CourierEventState.Begin;
        }
        public BeginEvent(string name)
        {
            state = CourierEventState.Begin;
            this.name = name;
        }
    }

    public class CompleteEvent : CourierEvent
    {
        public CompleteEvent()
        {
            state = CourierEventState.Complete;
        }
        public CompleteEvent(string name)
        {
            state = CourierEventState.Complete;
            this.name = name;
        }
    }
}