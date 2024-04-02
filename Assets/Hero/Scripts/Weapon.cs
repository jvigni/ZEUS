using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : Equipable
{
    [SerializeField] ThirdPersonController _thirdPersonController;

    public override void OnEquip() 
    {
        //_thirdPersonController.SetCombatCamera(true);
        Wielder.GetComponent<ThirdPersonController>().SetCombatCamera(true);
    }

    public override void OnUnequip()
    {
        //_thirdPersonController.SetCombatCamera(false);
        Wielder.GetComponent<ThirdPersonController>().SetCombatCamera(false);
    }
}
