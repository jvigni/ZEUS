using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Lifeform : MonoBehaviour
{
    [SerializeField] int maxHp = 100;
    public event Action OnDeath;
    public event Action<int> OnHealthLost;
    int hp;

    public bool IsAlive() => hp > 0;

    void Awake()
    {
        hp = maxHp;
    }

    public void TakeDamage(int damage, GameObject attacker)
    {
        hp -= damage;
        ColorChangeOnHit();
        OnHealthLost?.Invoke(damage);
        if (!IsAlive())
            Death();
    }

    void Death()
    {
        OnDeath?.Invoke();
        Destroy(gameObject);
    }

    async void ColorChangeOnHit()
    {
        Debug.Log("RED..");
        await Task.Delay(1000);
        Debug.Log("NORMAL.");
    }
}
