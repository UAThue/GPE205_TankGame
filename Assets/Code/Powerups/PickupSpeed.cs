using UnityEngine;

public class PickupSpeed : MonoBehaviour
{
    public PowerupSpeed powerup;

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
        // Get object we collided with's PowerupManager
        PowerupManager otherPowerupManager = other.gameObject.GetComponent<PowerupManager>();
        // Tell it to add this powerup
        if (otherPowerupManager != null)
        {
            otherPowerupManager.AddPowerup(powerup);
        }

        // Destroy this object
        Destroy(gameObject);
    }
}
