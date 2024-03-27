using UnityEngine;
using Cinemachine;
using UnityEngine.PlayerLoop;
using StarterAssets;

public class Gun : Weapon
{
    Animator _animator;

    void Awake()
    {
        _animator = Wielder.GetComponent<Animator>();
    }

    public override void LClickDown()
    {
        base.LClickDown();
        Debug.Log("PEW PEW"); // TODO
    }

    public override void OnEquip()
    {
        _animator.SetBool("RifleOn", true);
        Wielder.GetComponent<ThirdPersonShooterController>().enabled = true;
    }

    public override void OnUnequip()
    {
        _animator.SetBool("RifleOn", false);
        Wielder.GetComponent<ThirdPersonShooterController>().enabled = false;
    }
}
