using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    [SerializeField] List<Ability> abilities;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && abilities.Count > 0)
            abilities[0].Trigger();
        else if (Input.GetKeyDown(KeyCode.E) && abilities.Count > 1)
            abilities[1].Trigger();
    }
}
