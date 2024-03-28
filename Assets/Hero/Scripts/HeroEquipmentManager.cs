using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroEquipmentManager : MonoBehaviour
{
    [SerializeField] List<Equipable> equipables;
    public Equipable Equiped;

    void Update()
    {
        MouseInputs();
        EquipmentSwapInputs();
    }

    void MouseInputs()
    {
        if (Equiped == null) return;

        if (Input.GetKey(KeyCode.Mouse0))
            Equiped.LClickIsPressed();
        else if (Input.GetKeyUp(KeyCode.Mouse0))
            Equiped.LClickUp();

        if (Input.GetKey(KeyCode.Mouse1))
            Equiped.RClickIsPressed();
        else if (Input.GetKeyUp(KeyCode.Mouse1))
            Equiped.RClickUp();
    }

    void EquipmentSwapInputs()
    {
        if (equipables.Count > 0 && Input.GetKeyDown(KeyCode.Alpha1))
            Equip(equipables[0]);

        else if (equipables.Count > 1 && Input.GetKeyDown(KeyCode.Alpha2))
            Equip(equipables[1]);

        else if (equipables.Count > 2 && Input.GetKeyDown(KeyCode.Alpha3))
            Equip(equipables[2]);

        else if (equipables.Count > 3 && Input.GetKeyDown(KeyCode.Alpha4))
            Equip(equipables[3]);

        else if (equipables.Count > 4 && Input.GetKeyDown(KeyCode.Alpha5))
            Equip(equipables[4]);
    }

    void Equip(Equipable newEquipable)
    {
        if (Equiped != null)
            Equiped.Unequip();

        Equiped = newEquipable;
        newEquipable.Equip(gameObject);
    }
}
