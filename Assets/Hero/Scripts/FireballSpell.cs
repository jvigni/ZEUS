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
    [SerializeField] Transform spawnSpellPoint;

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

    internal void Shoot()
    {
        Debug.Log("CAST FIREBALL");
        _shooterController.Shoot(projectilePrefab, spawnSpellPoint);
        _animator.SetBool("Casting", false);
    }
}
