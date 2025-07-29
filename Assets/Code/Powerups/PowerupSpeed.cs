using UnityEngine;

[System.Serializable]
public class PowerupSpeed : Powerup
{
    public float speedBoostAmount;

    public override void Apply (PowerupManager target)
    {
        // Apply speed boost
        Pawn targetPawn = target.gameObject.GetComponent<Pawn>();
        if (targetPawn != null)
        {
            targetPawn.moveSpeed += speedBoostAmount;
        }
    }

    public override void Remove(PowerupManager target)
    {
        // Remove speed boost
        Pawn targetPawn = target.gameObject.GetComponent<Pawn>();
        if (targetPawn != null)
        {
            targetPawn.moveSpeed -= speedBoostAmount;
        }
    }
}
