using UnityEngine;

public class TankPawn : Pawn
{
    public override void Start()
    {
        // Get the Rigidbody component
        mover = GetComponent<TankMover>();
    }

    public override void Update()
    {
    }

    public override void MoveForward()
    {
       mover.MoveForward(moveSpeed);
    }

    public override void MoveBackward()
    {
        mover.MoveBackward(moveSpeed);
    }

    public override void RotateClockwise()
    {
        mover.RotateClockwise(turnSpeed);
    }

    public override void RotateCounterClockwise()
    {
        mover.RotateCounterClockwise(turnSpeed);
    }

    public override void StrafeRight()
    {
        // DO NOTHING. Tank's can't strafe.
    }

    public override void StrafeLeft()
    {
        // DO NOTHING. Tank's can't strafe.
    }

}
