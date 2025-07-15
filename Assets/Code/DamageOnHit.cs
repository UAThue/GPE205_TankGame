using UnityEngine;

public class DamageOnHit : MonoBehaviour
{
    public float damageDealtOnHit;
    public float lifespan = 10;

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
        Debug.Log("We hit "+other.gameObject.name);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, lifespan);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
