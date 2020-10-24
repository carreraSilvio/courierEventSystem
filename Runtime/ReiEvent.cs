namespace ReiEvents.Runtime
{
    public enum ReiEventState
    {
        None = 0,
        Begin = 1,
        Complete = 2,
        Progress = 3
    }

    public class ReiEvent : ReiEventBase
    {
        public string name;
        public ReiEventState state;

        public ReiEvent()
        {

        }

        public ReiEvent(string name)
        {
            this.name = name;
        }
    }

    public class BeginEvent : ReiEvent
    {
        public BeginEvent()
        {
            state = ReiEventState.Begin;
        }
        public BeginEvent(string name)
        {
            state = ReiEventState.Begin;
            this.name = name;
        }
    }

    public class CompleteEvent : ReiEvent
    {
        public CompleteEvent()
        {
            state = ReiEventState.Complete;
        }
        public CompleteEvent(string name)
        {
            state = ReiEventState.Complete;
            this.name = name;
        }
    }
}