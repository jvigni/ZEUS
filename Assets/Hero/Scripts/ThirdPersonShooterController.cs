using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;
using UnityEngine.UI;

public class ThirdPersonShooterController : MonoBehaviour
{
    [SerializeField] public GameObject _aimCamera;
    [SerializeField] public Image _crosshairImg;
    [SerializeField] Animator _animator;
    [SerializeField] ThirdPersonController _thirdPersonController;
    //[SerializeField] public float normalSensitivity = 1f;
    //[SerializeField] public float aimSensitivity = .5f;

    // Update is called once per frame
    void Update()
    {

        /*
        _isAiming = Input.GetKey(KeyCode.Mouse1);
        if (_isAiming)
        {
            _aimCamera.SetActive(_isAiming);
            _thirdPersonController.RotateOnMove = !_isAiming;
            _crosshairImg.gameObject.SetActive(_isAiming);
            HandleAim(true);
        }*/
    }

    public void Shoot(BulletProjectile projectile, Vector3 spawnPos)
    {
        Vector3 worldAimTarget = _thirdPersonController.AimPointTransform.position;
        Vector3 aimDir = (worldAimTarget - spawnPos).normalized;
        var instantiatedProjectile = Instantiate(projectile, spawnPos, Quaternion.LookRotation(aimDir));
        instantiatedProjectile.OnShooted(gameObject);
    }

    public void StopAiming()
    {
        _aimCamera.SetActive(false);
        //_thirdPersonController.RotateOnMove = true;
        _crosshairImg.gameObject.SetActive(false);
        _animator.SetBool("Aiming", false);
        _thirdPersonController.SetCombatCamera(false);
    }

    public void Aim()
    {
        _thirdPersonController.SetCombatCamera(true);
        _aimCamera.SetActive(true);
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
