using System.Linq;
using UnityEngine;

namespace Scenarios
{
    public class Scenario4 : Scenario
    {
        public override string GetDescription()
        {
            return "Artifacts slightly randomized, light barriers at fixed positions relative to artifacts" +
                   " blocking three random directions.";
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
        }

        public override void OnEnvironmentReset()
        {
            environment.lightBarriers[0].transform.position = environment.artifacts[0].transform.position + new Vector3(-2.0f, 0.5f, 0.0f);
            environment.lightBarriers[1].transform.position = environment.artifacts[0].transform.position + new Vector3(2.0f, 0.5f, 0.0f);
            environment.lightBarriers[2].transform.position = environment.artifacts[0].transform.position + new Vector3(0.0f, 0.5f, 2.0f);
            environment.lightBarriers[3].transform.position = environment.artifacts[0].transform.position + new Vector3(0.0f, 0.5f, -2.0f);
            
            environment.lightBarriers[4].transform.position = environment.artifacts[1].transform.position + new Vector3(-2.0f, 0.5f, 0.0f);
            environment.lightBarriers[5].transform.position = environment.artifacts[1].transform.position + new Vector3(2.0f, 0.5f, 0.0f);
            environment.lightBarriers[6].transform.position = environment.artifacts[1].transform.position + new Vector3(0.0f, 0.5f, -2.0f);
            environment.lightBarriers[7].transform.position = environment.artifacts[1].transform.position + new Vector3(0.0f, 0.5f, 2.0f);
            
            environment.lightBarriers[8].transform.position = environment.artifacts[2].transform.position + new Vector3(-2.0f, 0.5f, 0.0f);
            environment.lightBarriers[9].transform.position = environment.artifacts[2].transform.position + new Vector3(2.0f, 0.5f, 0.0f);
            environment.lightBarriers[10].transform.position = environment.artifacts[2].transform.position + new Vector3(0.0f, 0.5f, -2.0f);
            environment.lightBarriers[11].transform.position = environment.artifacts[2].transform.position + new Vector3(0.0f, 0.5f, 2.0f);
            
            int[] indices = {Random.Range(0, 4), Random.Range(4, 8), Random.Range(8, 12)};
            if (environment.artifacts[0].transform.position.z < 6.5f && indices[0] == 3)
            {
                indices[0] = Random.Range(0, 3);
            }
            if (environment.artifacts[2].transform.position.x < 6.5f && indices[2] == 8)
            {
                indices[2] = Random.Range(9, 12);
            }
            for (var i = 0; i < environment.lightBarriers.Length; i++)
            {
                environment.lightBarriers[i].SetActive(!indices.Contains(i));
            }
        }
    }
}