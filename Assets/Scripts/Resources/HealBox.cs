using System;

public class HealBox : Item
{
    public event Action<HealBox> Collected;

    public override void Remove()
    {
        Collected?.Invoke(this);

        base.Remove();
    }
}
