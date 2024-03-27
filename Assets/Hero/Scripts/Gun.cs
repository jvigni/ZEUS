using UnityEngine;
using Cinemachine;
using UnityEngine.PlayerLoop;
using StarterAssets;

public class Gun : Weapon
{
    ThirdPersonController _thirdPersonController;
    HeroAimManager _aimManager;
    Animator _animator;
    bool rifleOut;

    void Awake()
    {
        _aimManager = Wielder.GetComponent<HeroAimManager>();
        _animator = Wielder.GetComponent<Animator>();
    }

    void Update()
    {
        if (rifleOut && Input.GetKeyDown(KeyCode.Mouse1))
            _aimManager.Aim(true);

        if (rifleOut && Input.GetKeyUp(KeyCode.Mouse1))
        {
            _aimManager.Aim(false);
            rifleOut = false;
        }
    }

    public override void OnEquip()
    {
        _animator.SetTrigger("RifleOn");
        rifleOut = true;
        //Wielder.GetComponent<AimZoomController>().enabled = true;
    }

    public override void OnUnequip()
    {
        _animator.SetTrigger("RifleOff");
        //Wielder.GetComponent<AimZoomController>().enabled = false;
    }
}
