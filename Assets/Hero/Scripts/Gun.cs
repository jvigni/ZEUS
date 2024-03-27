using UnityEngine;
using Cinemachine;
using UnityEngine.PlayerLoop;

public class Gun : Weapon
{
    [SerializeField] HeroAimManager _aimManager;

    void Start()
    {
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
        //Wielder.GetComponent<AimZoomController>().enabled = true;
    }

    public override void OnUnequip()
    {
        //Wielder.GetComponent<AimZoomController>().enabled = false;
    }
}
