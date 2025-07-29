using UnityEngine;

[System.Serializable]
public class PowerupHeal : Powerup
{
    public float amountToHeal;

    public override void Apply (PowerupManager target)
    {
        // Heal the target
        //  Get the target's Health Component
        Health targetHealthComponent = target.gameObject.GetComponent<Health>();
        // If it has a health component
        if (targetHealthComponent != null)
        {
            // Tell that health component to take negative damage (Heal) 
            targetHealthComponent.TakeDamage(-amountToHeal);
        }
    }
    
    public override void Remove (PowerupManager target)
    {
        // Damage the target by the heal amount
        Health targetHealthComponent = target.gameObject.GetComponent<Health>();
        if (targetHealthComponent != null)
        {
            targetHealthComponent.TakeDamage(amountToHeal);
        }
    }
}
