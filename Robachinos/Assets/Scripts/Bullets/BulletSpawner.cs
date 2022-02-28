using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float SpawnRate = 2f;
    [SerializeField] float SpawnDelay = 2f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnBullet", SpawnDelay, SpawnRate);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void SpawnBullet()
    { 
        Instantiate(bulletPrefab, transform);
    }
}