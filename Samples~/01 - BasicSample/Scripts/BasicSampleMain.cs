using CourierEventSystem.Runtime;
using UnityEngine;

namespace CourierEventSystem.Samples.BasicSample
{
    public class BasicSampleMain : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            Courier.Register<BattleEvent>(Handler_One);
            Courier.Register<BattleEvent>(Handler_Two);
            Courier.Send(new BattleEvent() { id = 1 });

            Courier.Unregister<BattleEvent>(Handler_One);
            Courier.Send(new BattleEvent() { id = 3 });
        }
     
        private void Handler_One(CourierEventBase evt)
        {
            var casted = (BattleEvent)evt;
            Debug.Log(nameof(Handler_One) + " " + casted.id);
        }

        private void Handler_Two(CourierEventBase evt)
        {
            var casted = (BattleEvent)evt;
            Debug.Log(nameof(Handler_Two) + " " + casted.id);
        }
    }
}