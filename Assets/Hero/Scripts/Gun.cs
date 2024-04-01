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
    [SerializeField] float secondsToReload; // TODO Pasarlo a animacion
    [SerializeField] BulletProjectile projectilePrefab;
    [SerializeField] Transform spawnBulletPosition;
    bool isBulletInChamber = true;
    int actualBulletsInMagazine;
    bool reloading;
    Animator _animator;
    ThirdPersonShooterController _shooterController;

    void Awake()
    {
        _animator = Wielder.GetComponentInChildren<Animator>();
        _shooterController = Wielder.GetComponentInChildren<ThirdPersonShooterController>();
        actualBulletsInMagazine = bulletsPerMagazine;
    }

    public override void LClickIsPressed()
    {
        base.LClickIsPressed();
        if (reloading) return;

        _shooterController.Aim();

        if (isBulletInChamber)
        {
            Debug.Log("Shooting!");
            isBulletInChamber = false;
            _shooterController.Shoot(projectilePrefab, spawnBulletPosition);  
            //_animator.SetTrigger("Shoot");
            StartCoroutine(LoadNextBullet());
        }
        else
        {
            StartCoroutine(ReloadMagazine());
        }
    }

    IEnumerator LoadNextBullet()
    {
        reloading = true;
        if (actualBulletsInMagazine > 0)
        {
            yield return new WaitForSeconds(secondsBetweenBullets);
            actualBulletsInMagazine--;
            isBulletInChamber = true;
            reloading = false;
        }
        else // Auto reload
        {
            StartCoroutine(ReloadMagazine());
        }
    }

    IEnumerator ReloadMagazine()
    {
        Debug.Log("Reloading magazine..");
        reloading = true;
        //_animator.SetTrigger("Reload");
        yield return new WaitForSeconds(secondsToReload);
        actualBulletsInMagazine = bulletsPerMagazine;
        isBulletInChamber = true;
        reloading = false;
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

    public override void OnEquip()
    {
        base.OnEquip();
        reloading = false;
        _animator.SetBool("RifleOn", true);
        _animator.SetTrigger("RifleDraw");
        Wielder.GetComponentInChildren<ThirdPersonShooterController>().enabled = true;
    }

    public override void OnUnequip()
    {
        base.OnUnequip();
        _shooterController.StopAiming();
        _animator.SetBool("RifleOn", false);
        Wielder.GetComponentInChildren<ThirdPersonShooterController>().enabled = false;
    }
}
