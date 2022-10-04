using UnityEngine;

namespace Scenarios
{
    public class Scenario1 : Scenario
    {
        public override string GetDescription()
        {
            return "Artifacts slightly randomized, introduce two fixed light barriers that have to be passed before " +
                   "going into the sections with artifacts.";
        }

        public override void OnStart()
        {
            environment.lightBarriers = new GameObject[2];
            environment.lightBarriers[0] = InstantiateLightBarrier(-4.0f, 0.0f, 8.0f, 0.0f);
            environment.lightBarriers[1] = InstantiateLightBarrier(-3.0f, -6.0f, 8.0f, 90.0f);
        }
        
        public override void OnEnvironmentReset() {}
    }
}