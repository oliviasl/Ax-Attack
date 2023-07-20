using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonFire : MonoBehaviour
{
    [SerializeField] private GameObject myProjectile;
    [SerializeField] private float minSpawnTime = 0.5f;
    [SerializeField] private float maxSpawnTime = 2.0f;

    private float timer;
    private float currentSpawnTime;

    void Start()
    {
        currentSpawnTime = GetRandomSpawnTime();
    }
    
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= currentSpawnTime)
        {
            Instantiate(myProjectile, transform.position, Quaternion.identity);
            timer -= currentSpawnTime;
            currentSpawnTime = GetRandomSpawnTime();
        }
    }

    private float GetRandomSpawnTime()
    {
        return Random.Range(minSpawnTime, maxSpawnTime);
    }
}
