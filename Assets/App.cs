using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class App : MonoBehaviour
{
    void Awake()
    {

    }

    void OnApplicationFocus(bool hasFocus) // Unity event
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
}
