using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroAimManager : MonoBehaviour
{
    [SerializeField] public GameObject aimCam;
    [SerializeField] public Image crosshairImg;
    [SerializeField] public float normalSensitivity = 1f;
    [SerializeField] public float aimSensitivity = .5f;

    public void Aim(bool aim)
    {
        if (aim)
        {
            aimCam.SetActive(true);
            crosshairImg.gameObject.SetActive(true);
        }
        else
        {
            aimCam.SetActive(false);
            crosshairImg.gameObject.SetActive(false);
        }
    }
}
