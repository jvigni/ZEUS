using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballSpell : Weapon
{
    private Animator _animator;

    private void Awake()
    {
        _animator = Wielder.GetComponent<Animator>();
    }

    public override void OnEquip()
    {
        _animator.SetBool("spellFloating", true);
        base.OnEquip();
    }

    public override void OnUnequip()
    {
        _animator.SetBool("spellFloating", false);
        base.OnUnequip();
    }

    public override void LClickIsPressed()
    {
        base.LClickIsPressed();
        Debug.Log("CAST FIREBALL");
    }
}
