using UnityEngine;

public class AIController_Coward : AIController
{
    public float fleeDistance = 50;
    public float safeDistance = 25;
    [Range(0,1)] public float fleeHealthPercent = 0.5f; 


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void Start()
    {
        // Set our start state
        ChangeState(AIStates.GUARD);

        // Find player 0, if we can!
        TargetPlayerByNumber(0);        
    }

    // Update is called once per frame
    public override void Update()
    {
        // Finite State Machine
        switch (currentState)
        {
            case AIStates.GUARD:
                // DO WORK

                // If we don't have a target, target player 0
                if (target == null)
                {
                    TargetPlayerByNumber(0);
                }

                Guard();
                // CHECK FOR TRANSITIONS
                if (IsTargetWithinDistance(safeDistance))
                {
                    ChangeState(AIStates.BACKAWAYANDSHOOT);
                }
                break;
            case AIStates.BACKAWAYANDSHOOT:
                // DO WORK
                BackAway();
                Shoot();

                // CHECK FOR TRANSITIONS
                if (IsHealthBelowPercent(fleeHealthPercent))
                {
                    ChangeState(AIStates.FLEE);
                }

                if (!IsTargetWithinDistance(fleeDistance))
                {
                    ChangeState(AIStates.GUARD);
                }
                break;
            case AIStates.FLEE:
                // DO WORK
                Flee();
                // CHECK FOR TRANSITIONS
                if (!IsHealthBelowPercent(fleeHealthPercent))
                {
                    ChangeState(AIStates.BACKAWAYANDSHOOT);
                }

                if (!IsTargetWithinDistance(fleeDistance))
                {
                    ChangeState(AIStates.GUARD);
                }
                break;
        }
    }
}
