using UnityEngine;
using Cinemachine;
using UnityEngine.PlayerLoop;
using StarterAssets;
using System.Threading.Tasks;
using System.Collections;

public class Gun : Weapon
{
    [SerializeField] float secondsBetweenBullets;
    [SerializeField] int bulletsPerMagazine;
    [SerializeField] float secondsToReload;
    [SerializeField] BulletProjectile projectile;
    [SerializeField] Transform spawnBulletPosition;
    bool isBulletInChamber;
    int actualBulletsInMagazine;
    Animator _animator;
    ThirdPersonShooterController _shooterController;

    void Awake()
    {
        _animator = Wielder.GetComponent<Animator>();
        _shooterController = Wielder.GetComponent<ThirdPersonShooterController>();
    }

    public override void LClickIsPressed()
    {
        base.LClickIsPressed();
        _shooterController.Aim();
        //if (_shooterController.IsReadyToShoot) // Anim event deprecated (muy bugoso)
        Shoot();
    }

    public override void LClickUp()
    {
        base.LClickUp();
        _shooterController.StopAiming();
    }

    public override void RClickIsPressed()
    {
        base.RClickIsPressed();
        _shooterController.Aim();
    }

    public override void RClickUp()
    {
        base.RClickUp();
        _shooterController.StopAiming();
    }

    void Shoot()
    {
        if (isBulletInChamber)
        {
            _shooterController.Shoot(projectile, spawnBulletPosition.position);
            StartCoroutine(LoadNextBullet());
        }

        if (!isBulletInChamber) return;
        if (actualBulletsInMagazine < 1) return;

        isBulletInChamber = false;
    }

    IEnumerator LoadNextBullet()
    {
        if (actualBulletsInMagazine > 0)
        {
            yield return new WaitForSeconds(secondsBetweenBullets);
            actualBulletsInMagazine--;
            isBulletInChamber = true;
        }
        else
        { // Auto reload:
            yield return new WaitForSeconds(secondsToReload);
            actualBulletsInMagazine = bulletsPerMagazine;
        }
    }

    public override void OnEquip()
    {
        _animator.SetBool("RifleOn", true);
        Wielder.GetComponent<ThirdPersonShooterController>().enabled = true;
    }

    public override void OnUnequip()
    {
        _shooterController.StopAiming();
        _animator.SetBool("RifleOn", false);
        Wielder.GetComponent<ThirdPersonShooterController>().enabled = false;
    }
}
