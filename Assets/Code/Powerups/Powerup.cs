
[System.Serializable]
public abstract class Powerup 
{
    public bool isPermanent;
    public float duration;

    public abstract void Apply(PowerupManager target);
    public abstract void Remove(PowerupManager target);
}
