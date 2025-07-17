using UnityEngine;

public class AIController_DumbPatrol : AIController
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void Start()
    {
        ChangeState(AIStates.PATROL);
        base.Start();
    }

    public override void MakeDecisions()
    {
        switch (currentState)
        {
            case AIStates.PATROL:
                // DO WORK
                Patrol();
                // CHECK FOR TRANSITIONS
                // No transitions for this AI
                break;
        }
    }
}
