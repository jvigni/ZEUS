using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using StarterAssets;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;

public class ThirdPersonShooterController : MonoBehaviour
{
    [SerializeField] public CinemachineVirtualCamera _aimCamera;
    [SerializeField] public Image _crosshairImg;
    [SerializeField] Animator _animator;
    [SerializeField] ThirdPersonController _thirdPersonController;
    private bool _alreadyAiming;

    //[SerializeField] public float normalSensitivity = 1f;
    //[SerializeField] public float aimSensitivity = .5f;

    public void Shoot(BulletProjectile projectilePrefab, Transform spawnPos)
    {
        Vector3 aimDir = _thirdPersonController.AimPointTransform.position - spawnPos.position;
        var instantiatedProjectile = Instantiate(projectilePrefab, spawnPos.transform.position, Quaternion.LookRotation(aimDir)); //Quaternion.LookRotation(aimDir)
        instantiatedProjectile.OnShooted(gameObject);
    }

    public void StopAiming()
    {
        _alreadyAiming = false;
        _aimCamera.gameObject.SetActive(false);
        //_thirdPersonController.RotateOnMove = true;
        _crosshairImg.gameObject.SetActive(false);
        _animator.SetBool("Aiming", false);
        _thirdPersonController.SetCombatCamera(false);
    }

    public void Aim()
    {
        if (!_alreadyAiming)
        {
            _thirdPersonController.RotateTowards(_thirdPersonController.AimPointTransform.position);
            _alreadyAiming = true;
        }

        _thirdPersonController.SetCombatCamera(true);
        _aimCamera.gameObject.SetActive(true);
        _crosshairImg.gameObject.SetActive(true);
        _animator.SetBool("Aiming", true);
        /*
        Vector3 worldAimTarget = thirdPersonController.AimPointTransform.position;
        //worldAimTarget.y = transform.position.y;
        Vector3 aimDirection = (worldAimTarget - transform.position).normalized;
        transform.forward = Vector3.Lerp(transform.forward, aimDirection, Time.deltaTime * 20f);
        */
    }

}
