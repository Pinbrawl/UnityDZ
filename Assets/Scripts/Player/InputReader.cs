using UnityEngine;

public class InputReader : MonoBehaviour
{
    public const string Horizontal = "Horizontal";

    private bool _isJump;
    private bool _isAttack;
    private bool _isVampirism;

    private KeyCode _jumpKey = KeyCode.Space;
    private KeyCode _attackKey = KeyCode.Mouse0;
    private KeyCode _vampirismKey = KeyCode.E;

    public float Direction { get; private set; }

    private void Update()
    {
        Direction = Input.GetAxis(Horizontal);

        if (Input.GetKeyDown(_jumpKey))
            _isJump = true;

        if(Input.GetKeyDown(_attackKey))
            _isAttack = true;

        if (Input.GetKeyDown(_vampirismKey))
            _isVampirism = true;
    }

    public bool IsJump() => GetBoolAsTrigger(ref _isJump);
    public bool IsAttack() => GetBoolAsTrigger(ref _isAttack);
    public bool IsVampirism() => GetBoolAsTrigger(ref _isVampirism);

    private bool GetBoolAsTrigger(ref bool value)
    {
        bool localValue = value;
        value = false;
        return localValue;
    }
}
