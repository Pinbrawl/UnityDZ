using System;

public class Coin : Item
{
    public event Action<Coin> Collected;

    public override void Remove()
    {
        Collected?.Invoke(this);
        
        base.Remove();
    }
}