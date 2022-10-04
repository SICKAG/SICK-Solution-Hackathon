using UnityEngine;
using Random = UnityEngine.Random;
using Scenarios;

public class Environment : MonoBehaviour
{
    public ScenarioEnum selectedScenario;
    public GameObject lightBarrierPrefab;
    public GameObject guardPrefab;
    public GameObject obstaclePrefab;
    public GameObject[] artifacts;
    [TextArea(5,10)]
    public string description;

    [HideInInspector]
    public GameObject[] lightBarriers;

    
    
    private readonly float[] _xMin = { -2.0f, 3.5f, -8.0f };
    private readonly float[] _xMax = { 6.5f, 6.5f, -3.5f };
    private readonly float[] _zMin = { -8.0f, 3.5f, 1.0f };
    private readonly float[] _zMax = { -3.5f, 6.5f, 6.5f };

    private Scenario _scenario;


    private void Start()
    {
        _scenario = selectedScenario switch
        {
            ScenarioEnum.Scenario0 => new Scenario0(),
            ScenarioEnum.Scenario1 => new Scenario1(),
            ScenarioEnum.Scenario2 => new Scenario2(),
            ScenarioEnum.Scenario3 => new Scenario3(),
            ScenarioEnum.Scenario4 => new Scenario4(),
            ScenarioEnum.Scenario5 => new Scenario5(),
            ScenarioEnum.Scenario6 => new Scenario6(),
            ScenarioEnum.Scenario7 => new Scenario7(),
            ScenarioEnum.Scenario8 => new Scenario8(),
            ScenarioEnum.Scenario9 => new Scenario9(),
            _ => _scenario
        };

        _scenario.environment = this;
        _scenario.OnStart();
    }

    public void ResetEnvironment()
    {
        PositionAndActivateArtifacts();
        _scenario.OnEnvironmentReset();
    }

    private void PositionAndActivateArtifacts()
    {
        for (var i = 0; i < artifacts.Length; i++)
        {
            artifacts[i].transform.localPosition = new Vector3(Random.Range(_xMin[i], _xMax[i]), 0, Random.Range(_zMin[i], _zMax[i]));
            artifacts[i].SetActive(true);
        }
    }

    private void OnValidate()
    {
        _scenario = selectedScenario switch
        {
            ScenarioEnum.Scenario0 => new Scenario0(),
            ScenarioEnum.Scenario1 => new Scenario1(),
            ScenarioEnum.Scenario2 => new Scenario2(),
            ScenarioEnum.Scenario3 => new Scenario3(),
            ScenarioEnum.Scenario4 => new Scenario4(),
            ScenarioEnum.Scenario5 => new Scenario5(),
            ScenarioEnum.Scenario6 => new Scenario6(),
            ScenarioEnum.Scenario7 => new Scenario7(),
            ScenarioEnum.Scenario8 => new Scenario8(),
            ScenarioEnum.Scenario9 => new Scenario9(),
            _ => _scenario
        };
        description = _scenario.GetDescription();
    }
}