using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;
using UnityEngine.Scripting;
using UnityEngine.UI;

public class HeroAimManager : MonoBehaviour
{
    [SerializeField] public GameObject aimCam;
    [SerializeField] public Image crosshairImg;
    [SerializeField] public float normalSensitivity = 1f;
    [SerializeField] public float aimSensitivity = .5f;

    ThirdPersonController _thirdPersonController;
    Animator _animator;

    void Awake()
    {
        _thirdPersonController = GetComponent<ThirdPersonController>();
        _animator = GetComponent<Animator>();
    }

    public void Aim(bool aim)
    {
        if (aim)
        {
            Debug.Log("AIM ON");
            aimCam.SetActive(true);
            _thirdPersonController.CharacterRotationFollowsCamera = true;
            crosshairImg.gameObject.SetActive(true);
            _animator.SetBool("RifleAim", true);

        }
        else
        {
            Debug.Log("AIM OFF");
            aimCam.SetActive(false);
            _thirdPersonController.CharacterRotationFollowsCamera = false;
            crosshairImg.gameObject.SetActive(false);
            _animator.SetBool("RifleAim", true);
        }
    }
}
