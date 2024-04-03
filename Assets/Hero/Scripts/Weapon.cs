using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : Equipable {

    public override void OnEquip() 
    {
        Wielder.GetComponent<ThirdPersonController>().SetCombatCamera(true);
    }

    public override void OnUnequip()
    {
        Wielder.GetComponent<ThirdPersonController>().SetCombatCamera(false);
    }
}
