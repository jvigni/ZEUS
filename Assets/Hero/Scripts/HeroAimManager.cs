using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HeroAimManager : MonoBehaviour
{
    [SerializeField] GameObject aimCam;
    [SerializeField] Image crosshairImg;
    [SerializeField] private float normalSensitivity;
    [SerializeField] private float aimSensitivity;

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
