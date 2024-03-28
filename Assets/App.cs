using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class App : MonoBehaviour
{
    [SerializeField] GameObject helmet;

    void Awake()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            helmet.SetActive(!helmet.activeSelf);
    }

    void OnApplicationFocus(bool hasFocus) // Unity event
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
}
