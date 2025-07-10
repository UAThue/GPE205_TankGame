using UnityEngine;

public class TankShooter : Shooter
{
    public GameObject projectilePrefab;
    public Transform shootPosition;
    public float shootForce;   

    public override void Shoot()
    {
        // Create the bullet at the position rotation and scale of the shootPosition
        GameObject bulletObject = Instantiate<GameObject>(projectilePrefab, transform);

        // Get the DamageOnHit component from the bullet
        DamageOnHit damageComponent = bulletObject.GetComponent<DamageOnHit>();

        // Get the bullet rigidbody
        Rigidbody bulletRB = bulletObject.GetComponent<Rigidbody>();
        bulletRB.AddForce(bulletObject.transform.forward * shootForce);
    }

}
