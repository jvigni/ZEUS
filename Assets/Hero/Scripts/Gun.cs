using UnityEngine;
using Cinemachine;
using UnityEngine.PlayerLoop;

public class Gun : Weapon
{
    [SerializeField] HeroAimManager aimManager;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
            aimManager.Aim(true);

        if (Input.GetKeyUp(KeyCode.Mouse1))
            aimManager.Aim(false);
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
