using UnityEngine;

namespace Scenarios
{
    public class Scenario3 : Scenario
    {
        public override string GetDescription()
        {
            return "Artifacts slightly randomized, light barriers at fixed positions relative to artifacts" +
                   " blocking one direction (the fastest way). For artifact in separate room this is randomly" +
                   " one of two possible directions.";
        }

        public override void OnStart()
        {
            environment.lightBarriers = new GameObject[4];
            environment.lightBarriers[0] = InstantiateLightBarrier(0.0f, 0.0f, 4.0f, 90.0f);
            environment.lightBarriers[1] = InstantiateLightBarrier(0.0f, 0.0f, 4.0f, 0.0f);
            environment.lightBarriers[2] = InstantiateLightBarrier(0.0f, 0.0f, 4.0f, 90.0f);
            environment.lightBarriers[3] = InstantiateLightBarrier(0.0f, 0.0f, 4.0f, 0.0f);
        }

        public override void OnEnvironmentReset()
        {
            environment.lightBarriers[0].transform.position = environment.artifacts[0].transform.position + new Vector3(-2.0f, 0.5f, 0.0f);
            environment.lightBarriers[1].transform.position = environment.artifacts[1].transform.position + new Vector3(0.0f, 0.5f, -2.0f);
            environment.lightBarriers[2].transform.position = environment.artifacts[1].transform.position + new Vector3(-2.0f, 0.5f, 0.0f);
            environment.lightBarriers[3].transform.position = environment.artifacts[2].transform.position + new Vector3(0.0f, 0.5f, -2.0f);
            
            
            var randomValue = Random.Range(0.0f, 1.0f);
            environment.lightBarriers[1].SetActive(randomValue < 0.5f);
            environment.lightBarriers[2].SetActive(randomValue >= 0.5f);
        }
    }
}