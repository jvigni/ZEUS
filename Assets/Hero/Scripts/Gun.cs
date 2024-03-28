using UnityEngine;
using Cinemachine;
using UnityEngine.PlayerLoop;
using StarterAssets;

public class Gun : Weapon
{
    [SerializeField] float rateOfFire = 100f;
    [SerializeField] BulletProjectile projectile;
    [SerializeField] Transform spawnBulletPosition;
    float rateOfFireCountdown;
    Animator _animator;
    ThirdPersonShooterController _shooterController;

    void Awake()
    {
        _animator = Wielder.GetComponent<Animator>();
        _shooterController = Wielder.GetComponent<ThirdPersonShooterController>();
    }

    void Update()
    {
        if (rateOfFireCountdown > 0)
            rateOfFireCountdown--;
    }

    public override void LClickIsPressed()
    {
        base.LClickIsPressed();
        Shoot();
    }

    void Shoot()
    {
        if (rateOfFireCountdown > 0)
            return;

        rateOfFireCountdown = rateOfFire;
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
