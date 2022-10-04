using UnityEngine;

namespace Scenarios
{
    public class Scenario8 : Scenario
    {
        private GameObject _guard1;
        private GameObject _guard2;

        public override string GetDescription()
        {
            return "Artifacts slightly randomized, introduce two guards that move in circles around museum" +
                   " with field of view acting as light barrier.";
        }

        public override void OnStart()
        {
            _guard1 = Object.Instantiate(environment.guardPrefab, environment.gameObject.transform);
            _guard2 = Object.Instantiate(environment.guardPrefab, environment.gameObject.transform);
        }

        public override void OnEnvironmentReset()
        {
            _guard1.transform.localPosition = new Vector3(0.0f, 0.0f, -5.0f);
            _guard1.transform.localRotation = Quaternion.Euler(0.0f, 90.0f, 0.0f);
            _guard2.transform.localPosition = new Vector3(0.0f, 0.0f, 5.0f);
            _guard2.transform.localRotation = Quaternion.Euler(0.0f, -90.0f, 0.0f);
        }
    }
}