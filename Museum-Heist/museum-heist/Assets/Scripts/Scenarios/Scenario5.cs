using UnityEngine;

namespace Scenarios
{
    public class Scenario5 : Scenario
    {
        public override string GetDescription()
        {
            return "Artifacts slightly randomized, low light barriers around artifacts" +
                   " that need to be jumped over.";
        }

        public override void OnStart()
        {
            environment.lightBarriers = new GameObject[12];
            
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

            foreach (var lightBarrier in environment.lightBarriers)
            {
                SetLightBarrierToLow(lightBarrier);
            }
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