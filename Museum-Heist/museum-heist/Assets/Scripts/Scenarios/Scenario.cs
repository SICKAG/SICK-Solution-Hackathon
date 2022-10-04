using UnityEngine;

namespace Scenarios
{
    public abstract class Scenario
    {
        public Environment environment;

        public abstract string GetDescription();

        public abstract void OnStart();
        public abstract void OnEnvironmentReset();

        protected GameObject InstantiateLightBarrier(float x, float z, float width, float angle)
        {
            var lightBarrier = Object.Instantiate(environment.lightBarrierPrefab, environment.gameObject.transform);
            lightBarrier.transform.localPosition = new Vector3(x, 0.5f, z);
            lightBarrier.transform.localScale = new Vector3(width, 3.0f, 0.2f);
            lightBarrier.transform.localRotation = Quaternion.Euler(0.0f, angle, 0.0f);
            return lightBarrier;
        }

        protected static void SetLightBarrierToLow(GameObject lightBarrier) // can be jumped over
        {
            var position = lightBarrier.transform.localPosition;
            position.y = -0.5f;
            lightBarrier.transform.localPosition = position;
            var scale = lightBarrier.transform.localScale;
            scale.y = 1.0f;
            lightBarrier.transform.localScale = scale;
        }
        
        protected static void SetLightBarrierToHigh(GameObject lightBarrier) // can be crawled under
        {
            var position = lightBarrier.transform.localPosition;
            position.y = 1.25f;
            lightBarrier.transform.localPosition = position;
            var scale = lightBarrier.transform.localScale;
            scale.y = 1.5f;
            lightBarrier.transform.localScale = scale;
        }
        
        protected static void SetLightBarrierToMedium(GameObject lightBarrier) // can be jumped over using obstacle
        {
            var position = lightBarrier.transform.localPosition;
            position.y = 0f;
            lightBarrier.transform.localPosition = position;
            var scale = lightBarrier.transform.localScale;
            scale.y = 2.0f;
            lightBarrier.transform.localScale = scale;
        }
        
        protected static void SetLightBarrierToFull(GameObject lightBarrier) // cannot be passed
        {
            var position = lightBarrier.transform.localPosition;
            position.y = 0.5f;
            lightBarrier.transform.localPosition = position;
            var scale = lightBarrier.transform.localScale;
            scale.y = 3.0f;
            lightBarrier.transform.localScale = scale;
        }
        
    }

    public enum ScenarioEnum{
        Scenario0,
        Scenario1,
        Scenario2,
        Scenario3,
        Scenario4,
        Scenario5,
        Scenario6,
        Scenario7,
        Scenario8,
        Scenario9
    }
}