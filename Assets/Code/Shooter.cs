using UnityEngine;

public abstract class Shooter : MonoBehaviour
{
    public abstract void Start();
    public abstract void Shoot(Pawn shooterPawn);
    public abstract void TryShoot(Pawn shooterPawn);
    public float shootingNoiseVolume;

}
