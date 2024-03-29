using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;
using UnityEngine.UI;

public class ThirdPersonShooterController : MonoBehaviour
{
    [SerializeField] Transform aimTargetTransform;
    [SerializeField] public GameObject _aimCamera;
    [SerializeField] public Image _crosshairImg;
    [SerializeField] private LayerMask _aimColliderLayerMask;
    Animator _animator;
    ThirdPersonController _thirdPersonController;
    //[SerializeField] public float normalSensitivity = 1f;
    //[SerializeField] public float aimSensitivity = .5f;

    void Awake()
    {
        _thirdPersonController = GetComponent<ThirdPersonController>();
        _animator = GetComponent<Animator>();
    }

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
        var aimDir = (CalculateWorldAimPosition() - spawnPos).normalized;
        var instantiatedProjectile = Instantiate(projectile, spawnPos, Quaternion.LookRotation(aimDir));
        instantiatedProjectile.OnShooted(gameObject);
    }

    public void StopAiming()
    {
        _aimCamera.SetActive(false);
        _thirdPersonController.RotateOnMove = true;
        _crosshairImg.gameObject.SetActive(false);
        _animator.SetBool("Aiming", false);
    }

    public void Aim()
    {
        _aimCamera.SetActive(true);
        _thirdPersonController.RotateOnMove = false;
        _crosshairImg.gameObject.SetActive(true);
        _animator.SetBool("Aiming", true);
        Vector3 worldAimTarget = CalculateWorldAimPosition();
        worldAimTarget.y = transform.position.y;
        Vector3 aimDirection = (worldAimTarget - transform.position).normalized;
        transform.forward = Vector3.Lerp(transform.forward, aimDirection, Time.deltaTime * 20f);
    }

    Vector3 CalculateWorldAimPosition()
    {
        var mouseWorldPosition = Vector3.zero;
        var screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint); //Input.mousePosition
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, _aimColliderLayerMask))
        {
            aimTargetTransform.position = raycastHit.point;
            mouseWorldPosition = raycastHit.point;
        }
        else
        {
            aimTargetTransform.position = ray.direction * 999f;
            mouseWorldPosition = ray.direction * 999f;
        }
        return mouseWorldPosition;
    }
}
