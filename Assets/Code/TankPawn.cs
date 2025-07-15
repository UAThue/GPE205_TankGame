using UnityEngine;

public class TankPawn : Pawn
{
    public void Awake()
    {
    }

    public override void Start()
    {
        // Add ourselves to the GameManager list!
        GameManager.instance.pawns.Add(this);

        // Change our object name
        gameObject.name = "TankPawn " + GameManager.instance.pawns.Count;

        // Get the Mover component
        mover = GetComponent<Mover>();
        // Get the Shooter component
        shooter = GetComponent<Shooter>();
    }

    public override void Update()
    {
    }

    public void OnDestroy()
    {
        // Remove us from the GameManager List
        GameManager.instance.pawns.Remove(this);
    }

    public override void Shoot()
    {
        // Tell the Shooter component to shoot
        shooter.TryShoot(this);
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
