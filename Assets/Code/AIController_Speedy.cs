using UnityEngine;

public class AIController_Speedy : AIController
{
    // Finite State Machine Switch/Case for Speedy
    public override void MakeDecisions()
    {
        // Switch Case based on state enum
        switch (currentState)
        {
            //   Based on our state, call the function(s) for that state's action(s)
            case AIStates.GUARD:
                // Do Work
                Guard();
                // TODO: Check for transitions
                break;
            case AIStates.CHASE:
                // Do Work
                Chase();
                // TODO: Check for transitions
                break;
            case AIStates.CHASEANDSHOOT:
                // Do Work
                Chase();
                Shoot();
                // TODO: Check for transitions
                break;
            case AIStates.FLEE:
                // Do Work
                Flee();
                // TODO: Check for transitions
                break;
            case AIStates.BACKAWAY:
                // Do Work
                BackAway();
                // TODO: Check for transitions
                break;
            case AIStates.STANDANDSHOOT:
                // Do Work
                Shoot();
                // TODO: Check for transitions
                break;
            default:
                // Do Work
                // Do nothing
                // TODO: Check for transitions
                break;

        }
    }
}
