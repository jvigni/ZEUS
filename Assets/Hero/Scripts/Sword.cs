using UnityEngine;

public class Sword : Weapon
{
    [SerializeField] private bool isAttacking;
    [SerializeField] private int attack_combo_state = 0;
    [SerializeField] private int comboCountdown;
    Animator _animator;

    void Start()
    {
        _animator = Wielder.GetComponent<Animator>();
    }

    void Update()
    {
        if (isAttacking) return;

        if (comboCountdown > 0)
            comboCountdown--;
        else
            attack_combo_state = 0;

        if (Input.GetKey(KeyCode.Mouse0))
            LeftClickAttack();
        else if (Input.GetKeyDown(KeyCode.Mouse1))
            RightClickAttack();
    }

    void RightClickAttack()
    {
        if (isAttacking) return;

        isAttacking = true;
        _animator.SetTrigger("AttackR");
    }

    async void LeftClickAttack() // TODO revisar. await no va?
    {
        if (isAttacking) return;

        isAttacking = true;
        attack_combo_state++;
        if (attack_combo_state > 2) attack_combo_state = 1;

        //var thirdPersonController = GetComponent<ThirdPersonController>();
        //var originalMoveSpeed = thirdPersonController.MoveSpeed;
        //thirdPersonController.MoveSpeed = originalMoveSpeed * 0.2f;

        if (attack_combo_state == 2)
        {
            _animator.SetTrigger("AttackL2");
            return;
        }

        else if (attack_combo_state == 1)
        {
            _animator.SetTrigger("AttackL");
            comboCountdown = 500;
            return;
        }

        //await Task.Delay(1000); // TODO ranciada. tiene que recuperar la speed en onAttackEnd()..
        //thirdPersonController.MoveSpeed = originalMoveSpeed;
    }

    public override void OnAnimationHit()
    {
        Debug.Log("Anim hit");
        //isAttacking = false; // TODO REMVE. must go on OnAnimationEnd only
    }

    public override void OnAnimationEnd()
    {
        Debug.Log("ANIM END");
        isAttacking = false;
    }

    public override bool CanUnequip()
    {
        return !isAttacking;
    }
}
