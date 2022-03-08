using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject bulletGenerator;
    public float cooldownTimer = 0f;
    [SerializeField] float cooldownTime = 1f;
    public bool setTimerCooldown = false;

    public bool EnemyCanShoot = false;
        public  AudioClip bulletSound;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        SpawnBullet();

    }
    private void SpawnBullet()
    {
        if (EnemyCanShoot == true && setTimerCooldown == false)
        {
            Instantiate(bulletPrefab,  transform.position ,transform.rotation );
            AudioManager.instance.PlaySound(bulletSound);
            setTimerCooldown = true;
        }
        if (setTimerCooldown == true)
        {
            cooldownTimer += Time.deltaTime;
        }
        if (cooldownTimer > cooldownTime)
        {
            cooldownTimer = 0;
            setTimerCooldown = false;
        }
    }
}
