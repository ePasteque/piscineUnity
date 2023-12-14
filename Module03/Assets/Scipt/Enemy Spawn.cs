using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemy;
    public float spawnTime = 3f;

    void Start()
    {
        InvokeRepeating("Spawn", 0f, spawnTime);
    }

    void Spawn()
    {
        Instantiate(enemy, transform.position, transform.rotation, gameObject.transform);
    }
}
