using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// For animation events
public class AnimationReceiver : MonoBehaviour
{
    [SerializeField] GameObject sword;

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

    void ShootFire()
    {
        //var fireballSpell = (FireballSpell)GetComponent<HeroEquipmentManager>().Equiped;
        //fireballSpell.Shoot();
        var fireballAbility = GetComponentInChildren<FireballAbility>();
        fireballAbility.ShootFireball();
    }

    void TakeSword()
    {

    }
}
