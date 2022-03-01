using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySeePlayer : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float enemySeeMaxDistance = 2f;
    [SerializeField] float enemyViewAngle = 2f;
    Vector3 enemySeeDirection;
    RaycastHit hit;
    [SerializeField] GameObject luzGeneral;
    public bool enemySeePlayer;
    private float hitDistance;
    private GameObject bulletGenerator;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("---PLAYER---");
        bulletGenerator = GameObject.Find("EnemyBulletGenerator");
    }

    // Update is called once per frame
    void Update()
    {
        LookAtPlayer();

    }

    private void LookAtPlayer()
    {
        if (enemySeePlayer == true)
        {
            transform.LookAt(player.transform.position);
        }
    }

    void FixedUpdate()
    {

        EnemySeeTargetCheck();
    }

    private void EnemySeeTargetCheck()
    {
        //funciona sólo con las luces prendidas
        if (luzGeneral.activeSelf)
        {
            //calculo el vector de movimiento desde enemy a player
            enemySeeDirection = (player.transform.position - transform.position);
            hitDistance = enemySeeDirection.magnitude;
            if (Vector3.Angle(transform.forward, enemySeeDirection) <= enemyViewAngle && enemySeeDirection.magnitude <= enemySeeMaxDistance)
            {
                //emulo un rayo desde la posicion del enemy hasta el player
                if (Physics.Raycast(transform.position, enemySeeDirection, out hit, enemySeeMaxDistance))
                {
                    enemySeePlayer = true;
                    bulletGenerator.GetComponent<BulletSpawner>().EnemyCanShoot = true;
                }
            }
            else
            {
                enemySeePlayer = false;
                bulletGenerator.GetComponent<BulletSpawner>().EnemyCanShoot = false;
            }
        }
        

    }
}
