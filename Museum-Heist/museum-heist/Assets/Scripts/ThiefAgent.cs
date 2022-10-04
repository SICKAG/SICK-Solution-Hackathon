using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;

public class ThiefAgent : Agent
{
    public Environment environment;
    private CharacterController _controller;
    private Movement _movement;

    private uint _actionCount = 0;

    private void Start()
    {
        _controller = gameObject.AddComponent<CharacterController>();
        _movement = new Movement(_controller, transform);
    }
    
    public override void OnEpisodeBegin()
    {
        Debug.Log($"Episode Done: actions: {_actionCount}, steps: {StepCount}, reward: {GetCumulativeReward()}");

        _actionCount = 0;
        
        _movement.Reset();
        environment.ResetEnvironment();
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.localPosition.x / 10.0f);
        sensor.AddObservation(transform.localPosition.z / 10.0f);
    }
    
    public override void OnActionReceived(ActionBuffers actionBuffers)
    {
        // comment in for debugging
        /*if (_actionCount % 1000 == 0)
        {
            Debug.Log($"Steps: {_actionCount}, Current Reward: {GetCumulativeReward()}, observations: {GetObservations().Count}");
        }
        _actionCount += 1;*/

        // Turn
        _movement.Turn(actionBuffers.ContinuousActions[1]);

        // Set movement mode
        var mode = actionBuffers.DiscreteActions[0] switch
        {
            0 => MoveMode.Normal,
            1 => MoveMode.Jump,
            2 => MoveMode.Crawl,
            _ => MoveMode.Normal
        };
        // Request the movement
        _movement.Forward(actionBuffers.ContinuousActions[0], mode);
    }
    
    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var continuousActionsOut = actionsOut.ContinuousActions;
        var discreteActionsOut = actionsOut.DiscreteActions;
        continuousActionsOut[0] = Input.GetAxis("Vertical");
        continuousActionsOut[1] = Input.GetAxis("Horizontal");
        discreteActionsOut[0] = Input.GetKey("1") ? 1 : 0;
        discreteActionsOut[0] = Input.GetKey("2") ? 2 : discreteActionsOut[0];
    }


    public void OnArtifactCollected()
    {
        AddReward(1.0f);
    }
    
    public void OnDoorTriggered()
    {
        SetReward(0.2f);
        EndEpisode();
    }
    
    public void OnLightBarrierTriggered()
    {
        SetReward(-1.0f);
        EndEpisode();
    }
}
