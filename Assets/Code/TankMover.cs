using UnityEngine;

public class TankMover : Mover
{
    // Tanks move via a rigidbody, so we include that here
    public new Rigidbody rigidbody;
    public NoiseMaker noiseMaker;
    public float movementNoiseVolume;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        noiseMaker = GetComponent<NoiseMaker>();
    }
    public override void Update()
    {
    }

    public override void MoveForward(float moveSpeed)
    {
        // Move forward from the current position based on our move speed and the frame rate
        rigidbody.MovePosition(rigidbody.position + (transform.forward * moveSpeed * Time.deltaTime));

        // If we have a noisemaker, make some noise
        if (noiseMaker != null) noiseMaker.MakeNoise(movementNoiseVolume);
    }
    public override void MoveBackward(float moveSpeed)
    {
        // Move backward from the current position based on our move speed and the frame rate
        rigidbody.MovePosition(rigidbody.position + (-transform.forward * moveSpeed * Time.deltaTime));
        // If we have a noisemaker, make some noise
        if (noiseMaker != null) noiseMaker.MakeNoise(movementNoiseVolume);
    }

    public override void RotateClockwise(float turnSpeed)
    {
        // Rotate clockwise based on our turn speed and the frame rate
        transform.Rotate(0, turnSpeed * Time.deltaTime, 0);
        // If we have a noisemaker, make some noise
        if (noiseMaker != null) noiseMaker.MakeNoise(movementNoiseVolume);
    }

    public override void RotateCounterClockwise(float turnSpeed)
    {
        // Rotate counter-clockwise based on our turn speed and the frame rate
        transform.Rotate(0, -turnSpeed * Time.deltaTime, 0);
        // If we have a noisemaker, make some noise
        if (noiseMaker != null) noiseMaker.MakeNoise(movementNoiseVolume);
    }

    public override void StrafeRight(float moveSpeed)
    {
        // Do nothing - tank's don't strafe
    }

    public override void StrafeLeft(float moveSpeed)
    {
        // Do nothing - tank's don't strafe
    }
}
