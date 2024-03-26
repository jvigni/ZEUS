public class Gun : Weapon
{
    public override void OnEquip()
    {
        //Wielder.GetComponent<AimZoomController>().enabled = true;
    }

    public override void OnUnequip()
    {
        //Wielder.GetComponent<AimZoomController>().enabled = false;
    }
}
