namespace Scenarios
{
    public class Scenario0 : Scenario
    {
        public override string GetDescription()
        {
            return "Simplest scenario: Three artifacts spawned in slightly randomized positions, no light barriers.";
        }
        
        public override void OnStart() {}
        
        public override void OnEnvironmentReset() {}
    }
}