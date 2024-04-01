using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Provider
{
    public static GameObject Hero;
}

public class App : MonoBehaviour
{
    [SerializeField] GameObject helmet;
    [SerializeField] GameObject Hero;

    private void Awake()
    {
        Provider.Hero = Hero;
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
