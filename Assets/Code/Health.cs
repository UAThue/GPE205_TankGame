using UnityEngine;

public class Health : MonoBehaviour
{

    public float maxHealth;
    public float currentHealth;
    private Death deathComponent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Get the Death Component
        deathComponent = GetComponent<Death>();

        // Start with Max Health
        currentHealth = maxHealth;        
    }

    // Update is called once per frame
    void Update()
    {
        // TEST CODE DELETE ME!
        if (Input.GetKeyDown(KeyCode.P))
        {
            TakeDamage(1);
        }
    }

    // Take Damage
    public void TakeDamage (float damage)
    {
        // subtract from our health
        currentHealth -= damage;

        // Make sure we don't go outside the range of 0 to maxHealth
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        // If we took enough damage to die, then die
        if (currentHealth <= 0)
        {
           Die();
        }
    }

    public void Die()
    {
        // Call Die on the death component
        deathComponent.Die();
    }
}
