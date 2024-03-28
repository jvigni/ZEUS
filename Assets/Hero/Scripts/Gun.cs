using UnityEngine;
using Cinemachine;
using UnityEngine.PlayerLoop;
using StarterAssets;

public class Gun : Weapon
{
    [SerializeField] BulletProjectile projectile;
    [SerializeField] Transform spawnBulletPosition;
    Animator _animator;
    ThirdPersonShooterController _shooterController;

    void Awake()
    {
        _animator = Wielder.GetComponent<Animator>();
        _shooterController = Wielder.GetComponent<ThirdPersonShooterController>();
    }

    public override void LClickDown()
    {
        base.LClickDown();
        Debug.Log("PEW PEW");
        _shooterController.Shoot(projectile, spawnBulletPosition.position);
    }

    public override void OnEquip()
    {
        _animator.SetBool("RifleOn", true);
        Wielder.GetComponent<ThirdPersonShooterController>().enabled = true;
    }

    public override void OnUnequip()
    {
        _animator.SetBool("RifleOn", false);
        Wielder.GetComponent<ThirdPersonShooterController>().enabled = false;
    }
}
