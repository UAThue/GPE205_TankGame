using UnityEngine;

public class TankShooter : Shooter
{
    public GameObject projectilePrefab;
    public Transform shootPosition;
    [HideInInspector] public float nextShootTime;

    public AudioSource audioSource;

    private NoiseMaker noiseMaker;

    public override void Start()
    {
        // Get our components
        noiseMaker = GetComponent<NoiseMaker>();
        audioSource = GetComponent<AudioSource>();
    }

    public override void TryShoot(Pawn shooterPawn)
    {
        if (Time.time > nextShootTime)
        {
            Shoot(shooterPawn);            
        }
        
    }
    public override void Shoot(Pawn shooterPawn)
    {
        // Create the bullet at the position rotation and scale of the shootPosition
        GameObject bulletObject = Instantiate<GameObject>(projectilePrefab, shootPosition.position, shootPosition.rotation );

        // Get the DamageOnHit component from the bullet
        DamageOnHit damageComponent = bulletObject.GetComponent<DamageOnHit>();
        damageComponent.damageDealtOnHit = shooterPawn.damageDone;

        // Get the bullet rigidbody
        Rigidbody bulletRB = bulletObject.GetComponent<Rigidbody>();
        bulletRB.AddForce(bulletObject.transform.forward * shooterPawn.shootForce);

        // Set our next shoot time
        nextShootTime = Time.time + ( 1 / shooterPawn.shotsPerSecond );

        // Make noise if we have our noisemaker
        if (noiseMaker != null)
        {
            noiseMaker.MakeNoise(shootingNoiseVolume);
        }

        // Play the sound
        audioSource.Play();
    }

}
