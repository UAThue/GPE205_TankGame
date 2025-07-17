using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pawn : MonoBehaviour
{
    // Variable for move speed
    public float moveSpeed;
    // Variable for turn speed
    public float turnSpeed;
    // Variable for damage done
    public float damageDone = 1;
    // Variable for shoot force
    public float shootForce = 5000;
    // Shots per second
    public float shotsPerSecond = 2;

    // Component for moving
    [HideInInspector] public Mover mover;
    // Component for shooting
    [HideInInspector] public Shooter shooter;
    // Component for health
    [HideInInspector] public Health health;

    // Start is called before the first frame update
    public abstract void Start();

    // Update is called once per frame
    public abstract void Update();

    public abstract void MoveForward();
    public abstract void MoveBackward();
    public abstract void RotateClockwise();
    public abstract void RotateCounterClockwise();

    public abstract void RotateTowards(Vector3 position);

    public abstract void StrafeRight();
    public abstract void StrafeLeft();
    public abstract void Shoot();
}