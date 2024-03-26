using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroEquipmentManager : MonoBehaviour
{
    [SerializeField] List<Equipable> equipables;
    public Equipable Equiped;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            Equip(equipables[0]);

        else if (Input.GetKeyDown(KeyCode.Alpha2))
            Equip(equipables[1]);

        else if (Input.GetKeyDown(KeyCode.Alpha3))
            Equip(equipables[2]);

        else if (Input.GetKeyDown(KeyCode.Alpha4))
            Equip(equipables[3]);

        else if (Input.GetKeyDown(KeyCode.Alpha5))
            Equip(equipables[4]);
    }

    void Equip(Equipable newEquipable)
    {
        Debug.Log($"Equiping {newEquipable}");
        if (Equiped != null)
            Equiped.Unequip();

        Equiped = newEquipable;
        newEquipable.Equip(gameObject);
    }
}
