using UnityEngine;

public class PickupHeal : MonoBehaviour
{
    public PowerupHeal powerup;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        // Apply the powerup
        // Get the powerup manager of the other object that collided with us
        PowerupManager otherPowerupManager = other.gameObject.GetComponent<PowerupManager>();

        // If it has a powerup manager...
        if (otherPowerupManager != null)
        {
            // .. tell that manager to apply the powerup attached to this object
            otherPowerupManager.AddPowerup(powerup);
        }

        // Destroy this object
        Destroy(gameObject);
    }
}
