using UnityEngine;

public class AIController : Controller
{
    public enum AIStates { GUARD, CHASE, CHASEANDSHOOT, FLEE, BACKAWAY, BACKAWAYANDSHOOT, STANDANDSHOOT }
    public AIStates currentState;

    protected GameObject target;
    protected float lastStateChangeTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void Start()
    {
        currentState = AIStates.GUARD;
        TargetPlayerByNumber(0);
    }

    // Update is called once per frame
    public override void Update()
    {
        MakeDecisions(); 
    }

    public void TargetPlayerByNumber(int number)
    {
        if (GameManager.instance != null)
        {
            if (GameManager.instance.players.Count > 0)
            {
                if (GameManager.instance.players[number] != null)
                {
                    target = GameManager.instance.players[number].pawn.gameObject;
                    return;
                }
            }
        }

        Debug.LogWarning("ERROR: COULD NOT TARGET PLAYER " + number );
    }

    public void Guard()
    {
        // Rotate 
        pawn.RotateClockwise();

        // If we don't have a target, look for player 0
        // TODO: We can update this to target the first player we see!
        if (target == null)
        {
            TargetPlayerByNumber(0);
        }
    }
    public void Chase()
    {
        // Turn towards the target
        pawn.RotateTowards(target.transform.position);

        // Move forward
        pawn.MoveForward();
    }

    public void Flee()
    {
        // Turn away from the target
        // Find the vector to the target.
        Vector3 vectorToTarget = target.transform.position - pawn.transform.position;

        // Flip it so it points away from the target
        vectorToTarget = -vectorToTarget;

        // Find a point that is "that vector" away from our current location and rotate towards
        pawn.RotateTowards( pawn.transform.position + vectorToTarget );

        // move backward
        pawn.MoveForward();
    }

    public void Shoot()
    {
        // Shoot
        pawn.Shoot();
    }

    public void BackAway()
    {
        // Turn towards the target
        pawn.RotateTowards(target.transform.position);

        // Move Backward
        pawn.MoveBackward();
    }

    public override void MakeDecisions()
    {
        // Our Standard AI does nothing but guard
        Guard();
    }

    public bool IsHealthBelowPercent ( float healthPercent )
    {
        float currentHealthPercentage = pawn.health.currentHealth / pawn.health.maxHealth;
        if ( currentHealthPercentage <= healthPercent)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool IsTargetWithinDistance (float distance )
    {
        if (Vector3.Distance(pawn.transform.position, target.transform.position) < distance)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void ChangeState( AIStates newState)
    {
        // Change our state
        currentState = newState;

        // Save the time
        lastStateChangeTime = Time.time;
    }

}
