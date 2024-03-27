using UnityEngine;
using Cinemachine;
using UnityEngine.PlayerLoop;
using StarterAssets;

public class Gun : Weapon
{
    ThirdPersonController _thirdPersonController;
    HeroAimManager _aimManager;
    Animator _animator;

    void Awake()
    {
        _aimManager = Wielder.GetComponent<HeroAimManager>();
        _animator = Wielder.GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
            _aimManager.Aim(true);

        if (Input.GetKeyUp(KeyCode.Mouse1))
            _aimManager.Aim(false);
    }

    public override void OnEquip()
    {
        _animator.SetBool("RifleDraw", true);
        //Wielder.GetComponent<AimZoomController>().enabled = true;
    }

    public override void OnUnequip()
    {
        _animator.SetBool("RifleRest", false);
        //Wielder.GetComponent<AimZoomController>().enabled = false;
    }
}
