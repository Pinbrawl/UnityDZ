using System;

public class Coin : Item
{
    public event Action<Coin> Removed;

    public override void Remove()
    {
        Removed?.Invoke(this);
        
        base.Remove();
    }
}