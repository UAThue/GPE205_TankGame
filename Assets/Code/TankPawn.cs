using UnityEngine;
using static UnityEngine.GraphicsBuffer;

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
        // Get the Health component
        health = GetComponent<Health>();
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

    public override void RotateTowards(Vector3 targetPosition)
    {
        // Find the vector to the target -- 
        Vector3 vectorToTarget = targetPosition - this.transform.position;

        // Find how to rotate to look down that vector
        Quaternion rotationVector = Quaternion.LookRotation(vectorToTarget, Vector3.up);

        // Change our rotation A LITTLE BIT toward rotating down that vector
        this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, rotationVector, this.turnSpeed);
    }

    public override void Seek(Vector3 positionToSeek)
    {
        // Rotate Towards the target
        RotateTowards(positionToSeek);

        // Move forward
        MoveForward();
    }

    public override void Seek(GameObject objectToSeek)
    {
        Seek(objectToSeek.transform.position);
    }
    public override void Seek(Controller controllerToSeek)
    {
        Seek(controllerToSeek.pawn.gameObject);
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
