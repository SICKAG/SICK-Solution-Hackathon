using UnityEngine;

namespace Scenarios
{
    public class Scenario9 : Scenario
    {
        private GameObject _obstacle1;
        private GameObject _obstacle2;

        public override string GetDescription()
        {
            return "Artifacts slightly randomized, fixed barriers at start that can only be jumped over with help of objects." +
                   " Those are randomly spawned at two possible positions.";
        }

        public override void OnStart()
        {
            environment.lightBarriers = new GameObject[2];

            environment.lightBarriers[0] = InstantiateLightBarrier(-5.0f, 0.0f, 10.0f, 0.0f);
            environment.lightBarriers[1] = InstantiateLightBarrier(-3.0f, -5.0f, 10.0f, 90.0f);
            
            SetLightBarrierToMedium(environment.lightBarriers[0]);
            SetLightBarrierToMedium(environment.lightBarriers[1]);
            
            _obstacle1 = Object.Instantiate(environment.obstaclePrefab, environment.gameObject.transform);
            _obstacle2 = Object.Instantiate(environment.obstaclePrefab, environment.gameObject.transform);
        }

        public override void OnEnvironmentReset()
        {
            var randomValue = Random.value;
            if (randomValue < 0.5f)
            {
                _obstacle1.gameObject.transform.position = new Vector3(-9.0f, -0.5f, -1.5f);
                _obstacle2.gameObject.transform.position = new Vector3(-1.5f, -0.5f, -9.0f);
            }
            else
            {
                _obstacle1.gameObject.transform.position = new Vector3(-9.0f, -0.5f, 1.5f);
                _obstacle2.gameObject.transform.position = new Vector3(-4.5f, -0.5f, -9.0f);
            }
        }
    }
}