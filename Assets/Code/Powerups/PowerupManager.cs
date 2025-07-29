using UnityEngine;
using System.Collections.Generic;

public class PowerupManager : MonoBehaviour
{
    public List<Powerup> powerups;
    private List<Powerup> removalList;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Clear out our powerups list
        powerups = new List<Powerup>();
        removalList = new List<Powerup>();
    }

    // Update is called once per frame
    void Update()
    {
        DecrementPowerupTimers();
    }

    public void DecrementPowerupTimers()
    {
        foreach (Powerup powerup in powerups)
        {
            if (!powerup.isPermanent)
            {
                // Decrease it's duration
                powerup.duration -= Time.deltaTime;

                // If that duration is <= 0, add it to our removal list
                if (powerup.duration <= 0)
                {
                    removalList.Add(powerup);
                }
            }
        }

        // Now that we are DONE iterating through our powerup list, we can remove from it safely...
        // So, iterate through our removal list and remove every item in that list from the powerup list
        foreach (Powerup powerup in removalList)
        {
            RemovePowerup(powerup);
        }
        // Clear our removal list for next time
        removalList.Clear();
    }

    public void AddPowerup ( Powerup powerupToAdd)
    {
        // Apply the powerup to ourselves
        powerupToAdd.Apply(this);

        // Add it to our list of powerups
        powerups.Add(powerupToAdd);

    }

    public void RemovePowerup (Powerup powerupToRemove)
    {
        // Remove the powerup
        powerupToRemove.Remove(this);

        // Remove from list
        powerups.Remove(powerupToRemove);
    }

}
