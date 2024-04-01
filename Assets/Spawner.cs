using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] AlienAI monsterPrefab;

    private void Start()
    {
        InvokeRepeating("SummonEnemy", 0, 1);
    }

    void SummonEnemy()
    {
        var rad = 20;
        var spawnPos = new Vector3(Random.RandomRange(-rad, rad), 0, Random.RandomRange(-rad, rad));
        var instance = Instantiate(monsterPrefab, spawnPos, Quaternion.identity);
        instance.SetTarget(Provider.Hero.transform);
    }
}
