using UnityEngine;

namespace Scenarios
{
    public class Scenario2 : Scenario
    {
        public override string GetDescription()
        {
            return "Artifacts slightly randomized, fixed light barriers at the start" +
                   " and one of the two doors is randomly blocked by an additional light barrier";
        }

        public override void OnStart()
        {
            environment.lightBarriers = new GameObject[4];
            
            environment.lightBarriers[0] = InstantiateLightBarrier(5.0f, 0.0f, 2.0f, 0.0f);
            environment.lightBarriers[1] = InstantiateLightBarrier(0.0f, 5.0f, 2.0f, 90.0f);
            
            environment.lightBarriers[2] = InstantiateLightBarrier(-4.0f, 0.0f, 8.0f, 0.0f);
            environment.lightBarriers[3] = InstantiateLightBarrier(-3.0f, -6.0f, 8.0f, 90.0f);
        }

        public override void OnEnvironmentReset()
        {
            var randomValue = Random.value;
            environment.lightBarriers[0].SetActive(randomValue < 0.5f);
            environment.lightBarriers[1].SetActive(randomValue >= 0.5f);
        }
    }
}