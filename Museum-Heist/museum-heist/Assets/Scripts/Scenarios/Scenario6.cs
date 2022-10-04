using System.Linq;
using UnityEngine;

namespace Scenarios
{
    public class Scenario6 : Scenario
    {
        public override string GetDescription()
        {
            return "Artifacts slightly randomized, low light barriers around artifacts, additionally fixed high barriers" +
                   " at the start that need to be passed by crouching under.";
        }

        public override void OnStart()
        {
            environment.lightBarriers = new GameObject[16];
            
            environment.lightBarriers[0] = InstantiateLightBarrier(0.0f, 0.0f, 4.0f, 90.0f);
            environment.lightBarriers[1] = InstantiateLightBarrier(0.0f, 0.0f, 4.0f, 90.0f);
            environment.lightBarriers[2] = InstantiateLightBarrier(0.0f, 0.0f, 4.0f, 0.0f);
            environment.lightBarriers[3] = InstantiateLightBarrier(0.0f, 0.0f, 4.0f, 0.0f);
            
            environment.lightBarriers[4] = InstantiateLightBarrier(0.0f, 0.0f, 4.0f, 90.0f);
            environment.lightBarriers[5] = InstantiateLightBarrier(0.0f, 0.0f, 4.0f, 90.0f);
            environment.lightBarriers[6] = InstantiateLightBarrier(0.0f, 0.0f, 4.0f, 0.0f);
            environment.lightBarriers[7] = InstantiateLightBarrier(0.0f, 0.0f, 4.0f, 0.0f);
            
            environment.lightBarriers[8] = InstantiateLightBarrier(0.0f, 0.0f, 4.0f, 90.0f);
            environment.lightBarriers[9] = InstantiateLightBarrier(0.0f, 0.0f, 4.0f, 90.0f);
            environment.lightBarriers[10] = InstantiateLightBarrier(0.0f, 0.0f, 4.0f, 0.0f);
            environment.lightBarriers[11] = InstantiateLightBarrier(0.0f, 0.0f, 4.0f, 0.0f);
            
            environment.lightBarriers[12] = InstantiateLightBarrier(5.0f, 0.0f, 2.0f, 0.0f);
            environment.lightBarriers[13] = InstantiateLightBarrier(0.0f, 5.0f, 2.0f, 90.0f);
            environment.lightBarriers[14] = InstantiateLightBarrier(-5.0f, 0.0f, 10.0f, 0.0f);
            environment.lightBarriers[15] = InstantiateLightBarrier(-3.0f, -5.0f, 10.0f, 90.0f);
            
            foreach (var lightBarrier in environment.lightBarriers.Take(12))
            {
                SetLightBarrierToLow(lightBarrier);
            }
            
            SetLightBarrierToHigh(environment.lightBarriers[12]);
            SetLightBarrierToHigh(environment.lightBarriers[13]);
            SetLightBarrierToHigh(environment.lightBarriers[14]);
            SetLightBarrierToHigh(environment.lightBarriers[15]);
        }

        public override void OnEnvironmentReset()
        {
            environment.lightBarriers[0].transform.position = environment.artifacts[0].transform.position + new Vector3(-2.0f, -0.5f, 0.0f);
            environment.lightBarriers[1].transform.position = environment.artifacts[0].transform.position + new Vector3(2.0f, -0.5f, 0.0f);
            environment.lightBarriers[2].transform.position = environment.artifacts[0].transform.position + new Vector3(0.0f, -0.5f, 2.0f);
            environment.lightBarriers[3].transform.position = environment.artifacts[0].transform.position + new Vector3(0.0f, -0.5f, -2.0f);
            
            environment.lightBarriers[4].transform.position = environment.artifacts[1].transform.position + new Vector3(-2.0f, -0.5f, 0.0f);
            environment.lightBarriers[5].transform.position = environment.artifacts[1].transform.position + new Vector3(2.0f, -0.5f, 0.0f);
            environment.lightBarriers[6].transform.position = environment.artifacts[1].transform.position + new Vector3(0.0f, -0.5f, -2.0f);
            environment.lightBarriers[7].transform.position = environment.artifacts[1].transform.position + new Vector3(0.0f, -0.5f, 2.0f);
            
            environment.lightBarriers[8].transform.position = environment.artifacts[2].transform.position + new Vector3(-2.0f, -0.5f, 0.0f);
            environment.lightBarriers[9].transform.position = environment.artifacts[2].transform.position + new Vector3(2.0f, -0.5f, 0.0f);
            environment.lightBarriers[10].transform.position = environment.artifacts[2].transform.position + new Vector3(0.0f, -0.5f, -2.0f);
            environment.lightBarriers[11].transform.position = environment.artifacts[2].transform.position + new Vector3(0.0f, -0.5f, 2.0f);
        }
    }
}