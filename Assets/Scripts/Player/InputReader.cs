using UnityEngine;

public class InputReader : MonoBehaviour
{
    public const string Horizontal = "Horizontal";

    private bool _isJump;
    private bool _isAttack;

    private KeyCode _jumpKey = KeyCode.Space;
    private KeyCode _AttackKey = KeyCode.Mouse0;

    public float Direction { get; private set; }

    private void Update()
    {
        Direction = Input.GetAxis(Horizontal);

        if (Input.GetKeyDown(_jumpKey))
            _isJump = true;

        if(Input.GetKeyDown(_AttackKey))
            _isAttack = true;
    }

    public bool IsJump() => GetBoolAsTrigger(ref _isJump);
    public bool IsAttack() => GetBoolAsTrigger(ref _isAttack);

    private bool GetBoolAsTrigger(ref bool value)
    {
        bool localValue = value;
        value = false;
        return localValue;
    }
}
