using ReiEvents.Runtime;
using UnityEngine;

namespace ReiEvents.Samples.BasicSample
{
    public class BasicSampleMain : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            ReiEventSystem.AddHandler<BattleEvent>(Handler_One);
            ReiEventSystem.AddHandler<BattleEvent>(Handler_Two);
            ReiEventSystem.Invoke(new BattleEvent() { id = 1 });

            ReiEventSystem.RemoveHandler<BattleEvent>(Handler_One);
            ReiEventSystem.Invoke(new BattleEvent() { id = 3 });
        }
     
        private void Handler_One(ReiEventBase evt)
        {
            var casted = (BattleEvent)evt;
            Debug.Log(nameof(Handler_One) + " " + casted.id);
        }

        private void Handler_Two(ReiEventBase evt)
        {
            var casted = (BattleEvent)evt;
            Debug.Log(nameof(Handler_Two) + " " + casted.id);
        }
    }
}