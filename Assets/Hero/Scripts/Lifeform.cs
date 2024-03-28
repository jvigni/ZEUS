using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifeform : MonoBehaviour
{
    int life = 10;

    void Start()
    {

    }

    void Update()
    {

    }

    public void OnHit(GameObject agressor)
    {
        Debug.Log($"{gameObject.name} hitted by {agressor.name}");
        if (life < 0)
            Destroy(gameObject);
    }
}
