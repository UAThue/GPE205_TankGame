using UnityEngine;

public class AIController : Controller
{
    public enum AIStates { GUARD, CHASE, CHASEANDSHOOT, FLEE, BACKAWAY, STANDANDSHOOT }
    public AIStates currentState;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void Start()
    {
        currentState = AIStates.GUARD;
    }

    // Update is called once per frame
    public override void Update()
    {
        MakeDecisions(); 
    }

    public void Guard()
    {
        // Do Nothing!
    }
    public void Flee()
    {
        //TODO: turn AWAY from the player

        // Move forward
        pawn.MoveForward();
    }

    public void BackAway()
    {
        //TODO: turn toward the player

        // move backward
        pawn.MoveBackward();
    }

    public void Shoot()
    {
        // Shoot
        pawn.Shoot();
    }

    public void Chase()
    {
        // TODO: Turn towards player

        // Move Forward
        pawn.MoveForward();
    }

    public override void MakeDecisions()
    {
        // Our Standard AI does nothing but guard
        Guard();
    }
}
