using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using StarterAssets;
using UnityEngine;
using UnityEngine.UI;

public class ThirdPersonShooterController : MonoBehaviour
{
    [SerializeField] public CinemachineVirtualCamera _aimCamera;
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

    // tienen que salir derechos xd
    public void Shoot(BulletProjectile projectilePrefab, Transform spawnPos)
    {
        //Vector3 cameraPos = Camera.main.transform.position;
        //Vector3 aimDir = (spawnPos - cameraPos).normalized;
        //Vector3 aimDir = spawnPos.forward;
        Vector3 aimDir = _thirdPersonController.AimPointTransform.position - spawnPos.position;
        var instantiatedProjectile = Instantiate(projectilePrefab, spawnPos.transform.position, Quaternion.Euler(aimDir)); //Quaternion.LookRotation(aimDir)
        instantiatedProjectile.OnShooted(gameObject, aimDir);

        //Debug.DrawRay(spawnPos.transform.position, aimDir, Color.cyan);





        /*
        Vector3 worldAimTarget = _thirdPersonController.AimPointTransform.position;
        Vector3 aimDir = (worldAimTarget - spawnPos).normalized;
        var instantiatedProjectile = Instantiate(projectile, spawnPos, Quaternion.LookRotation(aimDir));
        instantiatedProjectile.OnShooted(gameObject);
        */

        /*
        Ray ray = _aimCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
            targetPoint = hit.point;
        else
            targetPoint = ray.GetPoint(75);

        var attackPoint = spawnPos;
        Vector3 directionWithoutSpread = targetPoint - attackPoint;
        */

        /*
        RaycastHit hit;
        if (Physics.Raycast(_aimCamera.transform.position, _aimCamera.transform.forward, out hit, Mathf.Infinity))
        {
            var instantiatedProjectile = Instantiate(projectile, spawnPos, Quaternion.identity);
            instantiatedProjectile.OnShooted(gameObject);
        }*/
    }

    public void StopAiming()
    {
        _aimCamera.gameObject.SetActive(false);
        //_thirdPersonController.RotateOnMove = true;
        _crosshairImg.gameObject.SetActive(false);
        _animator.SetBool("Aiming", false);
        _thirdPersonController.SetCombatCamera(false);
    }

    public void Aim()
    {
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
