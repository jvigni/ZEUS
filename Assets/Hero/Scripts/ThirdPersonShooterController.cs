using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;
using UnityEngine.UI;

public class ThirdPersonShooterController : MonoBehaviour
{
    [SerializeField] Transform debugTransform;
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
        var isAiming = Input.GetKey(KeyCode.Mouse1);
        HandleAim(isAiming);
    }

    public void Shoot(BulletProjectile projectile, Vector3 spawnPos)
    {
        var aimDir = (CalculateWorldAimPosition() - spawnPos).normalized;
        var instantiatedProjectile = Instantiate(projectile, spawnPos, Quaternion.LookRotation(aimDir));
        instantiatedProjectile.OnShooted(gameObject);
    }

    void HandleAim(bool isAiming)
    {
        _aimCamera.SetActive(isAiming);
        _thirdPersonController.RotateOnMove = !isAiming;
        _crosshairImg.gameObject.SetActive(isAiming);

        if (!isAiming)
        {
            _animator.SetBool("Aiming", false);
            return;
        }

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
            debugTransform.position = raycastHit.point;
            mouseWorldPosition = raycastHit.point;
        }
        return mouseWorldPosition;
    }
}
