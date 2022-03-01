using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletSpawner : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject bulletPrefab2;
    [SerializeField] GameObject bulletPrefab3;
    [SerializeField] GameObject bulletPoint;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            SpawnBullet1();
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            SpawnBullet2();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            SpawnBullet3();
        }
    }
    private void SpawnBullet1()
    {
        Instantiate(bulletPrefab, bulletPoint.transform.position, transform.rotation);
    }
    private void SpawnBullet2()
    {
        Instantiate(bulletPrefab2, bulletPoint.transform.position, transform.rotation);
    }
    private void SpawnBullet3()
    {
        Instantiate(bulletPrefab3, bulletPoint.transform.position, transform.rotation);

    }
}
