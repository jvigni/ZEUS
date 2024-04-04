using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballAbility : Ability
{
    [SerializeField] Animator _animator;
    [SerializeField] ThirdPersonShooterController _shooterController;
    [SerializeField] BulletProjectile _projectilePrefab;
    [SerializeField] Transform spawnSpellPoint;

    public override void Trigger()
    {
        base.Trigger();
        Debug.Log("CAST FIREBALL ABILITY");
        _animator.SetBool("Casting", true);
    }

    internal void ShootFireball()
    {
        Debug.Log("SHOOT FIREBALL ABILITY");
        _shooterController.Shoot(_projectilePrefab, spawnSpellPoint);
        _animator.SetBool("Casting", false);
    }
}
