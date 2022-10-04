using UnityEngine;
using System.Linq;

namespace Scenarios
{
    public class Scenario7 : Scenario
    {
        public override string GetDescription()
        {
            return "Random combination of obstacles so far: High/low barriers at start, artifacts completely blocked" +
                   " from three sides while fourth side needs jumping/crouching, random door blocked while other needs crouching.";
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
        }

        public override void OnEnvironmentReset()
        {
            foreach (var lightBarrier in environment.lightBarriers)
            {
                SetLightBarrierToFull(lightBarrier);
            }
            
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
            environment.lightBarriers[10].transform.position = environment.artifacts[2].transform.position + new Vector3(0.0f, 0.5f, 2.0f);
            environment.lightBarriers[11].transform.position = environment.artifacts[2].transform.position + new Vector3(0.0f, 0.5f, -2.0f);
            
            int[] indices = {Random.Range(0, 4), Random.Range(4, 8), Random.Range(8, 12)};
            if (environment.artifacts[0].transform.position.z < 6.5f && indices[0] == 3)
            {
                indices[0] = Random.Range(0, 3);
            }
            if (environment.artifacts[0].transform.position.x < 0.5f && indices[0] == 0)
            {
                indices[0] = Random.Range(1, 3);
            }
            if (environment.artifacts[2].transform.position.x < 6.5f && indices[2] == 8)
            {
                indices[2] = Random.Range(9, 12);
            }
            if (environment.artifacts[0].transform.position.z < 3.5f && indices[2] == 11)
            {
                indices[2] = Random.Range(9, 11);
            }
            for (var i = 0; i < environment.lightBarriers.Length; i++)
            {
                if (!indices.Contains(i)) continue;
                if (Random.value < 0.5f)
                {
                    SetLightBarrierToHigh(environment.lightBarriers[i]);
                }
                else
                {
                    SetLightBarrierToLow(environment.lightBarriers[i]);
                }
            }
            
            SetLightBarrierToHigh(Random.value < 0.5f ? environment.lightBarriers[12] : environment.lightBarriers[13]);
            if (Random.value < 0.5f)
            {
                SetLightBarrierToHigh(environment.lightBarriers[14]);
            }
            else
            {
                SetLightBarrierToLow(environment.lightBarriers[14]);
            }
            if (Random.value < 0.5f)
            {
                SetLightBarrierToHigh(environment.lightBarriers[15]);
            }
            else
            {
                SetLightBarrierToLow(environment.lightBarriers[15]);
            }
        }
    }
}