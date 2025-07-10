using UnityEngine;

public class DamageOnHit : MonoBehaviour
{
    public float damageDealtOnHit;

    public void OnTriggerEnter(Collider other)
    {
        // Damage the other object (if it has Health) on hit
        Health otherHealth = other.GetComponent<Health>();
        if (otherHealth != null)
        {
            otherHealth.TakeDamage(damageDealtOnHit);
        }
        // Destroy the bullet on hit
        Destroy(gameObject);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
