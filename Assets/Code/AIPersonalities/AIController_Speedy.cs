using UnityEngine;

public class AIController_Speedy : AIController
{
    // Finite State Machine Switch/Case for Speedy
    public override void Start()
    {
        ChangeState(AIStates.GUARD);
        base.Start();
    }
    public override void MakeDecisions()
    {
        // Switch Case based on state enum
        switch (currentState)
        {
            case AIStates.GUARD:
                // DO WORK
                Guard();

                // CHECK FOR TRANSITIONS AND CHANGE IF NEEDED
                if ((target != null))
                {
                    ChangeState(AIStates.CHASEANDSHOOT);
                }
                break;
            case AIStates.CHASEANDSHOOT:
                // DO WORK
                Chase();
                Shoot();

                // CHECK FOR TRANSITIONS AND CHANGE IF NEEDED
                if (IsTargetOutsideDistance(10))
                {
                    target = null;
                    ChangeState(AIStates.GUARD);
                }
                if (Time.time - lastStateChangeTime > 5)
                {
                    ChangeState(AIStates.GUARD);
                }
                break;        
        }
    }
}
