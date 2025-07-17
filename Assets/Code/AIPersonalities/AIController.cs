using System.Collections.Generic;
using UnityEngine;

public class AIController : Controller
{
    public enum AIStates { GUARD, CHASE, CHASEANDSHOOT, FLEE, BACKAWAY, BACKAWAYANDSHOOT, STANDANDSHOOT, PATROL }
    public AIStates currentState;

    protected GameObject target;
    protected float lastStateChangeTime;

    [Header("Patrol Values")]
    public List<Transform> waypoints;
    private int currentWaypoint = 0;
    public float seekCutoffDistance = 1;

    [Header("Sense Values")]
    public float hearingSensitivity;
    public float fieldOfView;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void Start()
    {
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





    public void Seek(Vector3 positionToSeek)
    {
        // Rotate Towards the target
        pawn.RotateTowards(positionToSeek);

        // Move forward
        pawn.MoveForward();
    }

    public void Seek(GameObject objectToSeek)
    {
        Seek(objectToSeek.transform.position);
    }

    public void Seek(Controller controllerToSeek)
    {
        Seek(controllerToSeek.pawn.gameObject);
    }


    public void Patrol()
    {
        // Go to the current point I'm patrolling
        Seek(waypoints[currentWaypoint].position);

        // If I am "close enough" to have reached that point, advance so I go to the next patrol point
        if (Vector3.Distance(pawn.transform.position, waypoints[currentWaypoint].position) <= seekCutoffDistance)
        {
            // Advance my current waypoint
            currentWaypoint++;

            // Make sure that if I go beyond the max waypoints, I loop back to zero
            if (currentWaypoint >= waypoints.Count)
            {
                currentWaypoint = 0;
            }
        }
    }

    public void Guard()
    {
        // Rotate 
        pawn.RotateClockwise();

        // If we don't have a target, target the first player we hear
        if (target == null)
        {
            foreach (Controller player in GameManager.instance.players)
            {
                if (CanSee(player.pawn.gameObject))
                {
                    target = player.pawn.gameObject;
                    return;
                }
                if (CanHear(player.pawn.gameObject))
                {
                    target = player.pawn.gameObject;
                    return;
                }
            }
        }

        // Otherwise, we couldn't hear anyone, set our target to null
        target = null;

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

    public bool IsTargetOutsideDistance (float distance)
    {
        // If we don't have a target, it can't be within distance
        if (target == null) return false;

        // Check if the target is within distance
        if (Vector3.Distance(pawn.transform.position, target.transform.position) > distance)
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
        // If we don't have a target, it can't be within distance
        if (target == null) return false;

        // Check if the target is within distance
        if (Vector3.Distance(pawn.transform.position, target.transform.position) < distance)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool CanSee ( GameObject target )
    {
        // If it doesn't exist, we can't see it
        if (target == null) 
        { 
            return false; 
        }

        // Get the vector to the object
        Vector3 vectorToTarget = target.transform.position - pawn.transform.position;
        
        // Find the angle between forward (the direction we are looking) and the vector to the target
        float angleToTarget = Vector3.Angle(vectorToTarget, pawn.transform.forward);

        // If this is greater than our view angle, the object is outside our FOV
        if (angleToTarget > fieldOfView)
        {
            return false;
        }

        // View point for our vision
        Vector3 eyePoint = pawn.transform.position + (Vector3.up * 2);

        // Cast a ray to the target
        RaycastHit hitInfo;
        if (Physics.Raycast(eyePoint, vectorToTarget, out hitInfo, Mathf.Infinity)) {
            // We hit something with our raycase.
            // If it is our target
            if (hitInfo.collider.gameObject == target)
            {
                // Then we can see it
                return true;
            } else
            {
                // Otherwise, we can't see it
                return false;
            }
        }

        // We did not hit anything with our Ray, so we can't see our target
        return false;
    }




    public bool CanHear ( GameObject target )
    {
        // If the target doesn't exist, you can't hear it
        if (target == null)
        {
            return false;
        }

        // Save the distance to our target
        float distanceToTarget = Vector3.Distance(target.transform.position, pawn.transform.position);
        
        // If the object CANNOT make noise, we didn't hear it.
        NoiseMaker targetNoiseMaker = target.GetComponent<NoiseMaker>();
        if ( targetNoiseMaker == null ) 
        {
            return false;
        }

        // If the two spheres overlap
        if ( targetNoiseMaker.noiseVolume + hearingSensitivity > distanceToTarget)
        {
            // We can hear the target
            return true;
        }

        // Otherwise
        return false;
    }



    public void ChangeState( AIStates newState)
    {
        // Change our state
        currentState = newState;

        // Save the time
        lastStateChangeTime = Time.time;
    }

}
