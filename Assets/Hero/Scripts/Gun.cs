using UnityEngine;
using Cinemachine;
using UnityEngine.PlayerLoop;

public class Gun : Weapon
{
    HeroAimManager _aimManager;
    Animator _animator;

    void Awake()
    {
        _animator = Wielder.GetComponent<Animator>();
        _aimManager = Wielder.GetComponent<HeroAimManager>();
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
        Debug.Log($"GUN ON EQUIP: {_animator}");
        _animator.SetBool("Rifle", true);
        //Wielder.GetComponent<AimZoomController>().enabled = true;
    }

    public override void OnUnequip()
    {
        _animator.SetBool("Rifle", false);
        //Wielder.GetComponent<AimZoomController>().enabled = false;
    }
}
