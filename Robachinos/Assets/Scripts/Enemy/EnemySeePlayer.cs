using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySeePlayer : MonoBehaviour
{
    [SerializeField] GameObject playerTarget;
    [SerializeField] float enemySeeMaxDistance = 2f;
    [SerializeField] float enemyViewAngle = 2f;
    Vector3 enemySeeDirection;
    RaycastHit hit;
    public bool enemySeePlayer;
    public float angulo;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //calculo el vector de movimiento desde enemy a player
        enemySeeDirection = (playerTarget.transform.position - transform.position);
        //calculo el ángulo entre el enemigo y el player
        angulo = Vector3.Angle(transform.forward, enemySeeDirection);
    }
    void FixedUpdate()
    {
        if (Vector3.Angle(transform.forward, enemySeeDirection) <= enemyViewAngle)
        {
            
            //emulo un rayo desde la posicion del enemy hasta el player
            Debug.Log(Physics.Raycast(transform.position, enemySeeDirection, out hit));

            if (Physics.Raycast(transform.position, enemySeeDirection, out hit))
            {
                Debug.DrawRay(transform.position, enemySeeDirection * hit.distance, Color.yellow, 99999999f);
                enemySeePlayer = true;
            }
        }
        else
        {
            enemySeePlayer = false;
        }
    }
}
