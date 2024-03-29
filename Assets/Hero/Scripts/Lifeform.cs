using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Lifeform : MonoBehaviour
{
    [SerializeField] int maxHp = 100;
    public event Action OnDeath;
    public event Action<int> OnHealthLost;
    int hp;
    int colorHitCountdown;

    public bool IsAlive() => hp > 0;

    void Awake()
    {
        hp = maxHp;
    }

    void Update()
    {
        if (colorHitCountdown > 0)
            colorHitCountdown--;
    }


    public void TakeDamage(int damage, GameObject attacker)
    {
        hp -= damage;
        OnHealthLost?.Invoke(damage);
        if (!IsAlive())
            Death();
    }

    void Death()
    {
        OnDeath?.Invoke();
        Destroy(gameObject);
    }
}
