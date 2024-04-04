using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class FireballSpell : Weapon
{
    private ThirdPersonShooterController _shooterController;
    private Animator _animator;
    [SerializeField] BulletProjectile projectilePrefab;

    private void Awake()
    {
        _shooterController = Wielder.GetComponentInChildren<ThirdPersonShooterController>();
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
        _animator.SetBool("Casting", true);
        //var casting = _animator.GetBool("Casting");
        //if (casting) return;
    }

    internal void Shoot()
    {
        Debug.Log("CAST FIREBALL");
        _shooterController.Shoot(projectilePrefab, transform);
        _animator.SetBool("Casting", false);
    }
}
