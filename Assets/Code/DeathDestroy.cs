using UnityEngine;

public class DeathDestroy : Death
{
    public override void Die()
    {
        // Object is just destroyed when it dies
        Destroy(gameObject); 
    }
}
