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
    public bool enemySeePlayer;
    public float hitDistance;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("---PLAYER---");
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
        //calculo el vector de movimiento desde enemy a player
        enemySeeDirection = (player.transform.position - transform.position);
        hitDistance = enemySeeDirection.magnitude;
        if (Vector3.Angle(transform.forward, enemySeeDirection) <= enemyViewAngle && enemySeeDirection.magnitude<=enemySeeMaxDistance)
        {
            //emulo un rayo desde la posicion del enemy hasta el player
            if (Physics.Raycast(transform.position, enemySeeDirection, out hit,enemySeeMaxDistance))
            {
                enemySeePlayer = true;
                
            }
        }
        else
        {
            enemySeePlayer = false;
        }
    }
}
