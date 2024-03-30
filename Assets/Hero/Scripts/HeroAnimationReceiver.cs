using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// For animation events
public class AnimationReceiver : MonoBehaviour
{
    void Hit() // Animation event
    {
        var equiped = GetComponentInParent<HeroEquipmentManager>().Equiped;
        equiped.OnAnimationHit();
    }

    void End()
    {
        var equiped = GetComponentInParent<HeroEquipmentManager>().Equiped;
        equiped.OnAnimationEnd();
    }

    void FootR()
    {

    }

    void FootL()
    {

    }
}
