using UnityEngine;

public abstract class Equipable : MonoBehaviour
{
    [SerializeField] protected GameObject Wielder;

    public virtual void Equip(GameObject wielder)
    {
        //Wielder = wielder;
        gameObject.SetActive(true);
        OnEquip();
    }

    public void Unequip()
    {
        gameObject.SetActive(false);
        OnUnequip();
    }

    public virtual void OnAnimationEnd() { }
    public virtual void OnAnimationHit() { }
    public virtual void OnEquip() { }
    public virtual void OnUnequip() { }
    public virtual bool CanUnequip() { return true; }

}
