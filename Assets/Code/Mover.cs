using UnityEngine;

public abstract class Mover : MonoBehaviour
{
    public abstract void Start();
    public abstract void Update();
    public abstract void MoveForward(float moveSpeed);
    public abstract void MoveBackward(float moveSpeed);
    public abstract void RotateClockwise(float turnSpeed);
    public abstract void RotateCounterClockwise(float turnSpeed);
    public abstract void StrafeRight(float moveSpeed);
    public abstract void StrafeLeft(float moveSpeed);

}
