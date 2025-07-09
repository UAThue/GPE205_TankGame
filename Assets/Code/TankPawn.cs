using UnityEngine;

public class TankPawn : Pawn
{
    public void Awake()
    {
        // Add ourselves to the GameManager list!
        GameManager.instance.pawns.Add(this);

        // Change our object name
        gameObject.name = "TankPawn " + GameManager.instance.pawns.Count;

    }

    public override void Start()
    {
        // Get the Rigidbody component
        mover = GetComponent<TankMover>();
    }

    public override void Update()
    {
    }

    public void OnDestroy()
    {
        // Remove us from the GameManager List
        GameManager.instance.pawns.Remove(this);
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
