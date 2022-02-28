using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySeePlayer : MonoBehaviour
{
    [SerializeField] GameObject playerTarget;
    [SerializeField] float enemySeeMaxDistance = 2f;
    [SerializeField] float enemyViewAngle = 2f;
    public Vector3 enemySeeDirection;
    private RaycastHit hit;
    public bool eneySeePlayer;
    public float angulo;
    public float magnitud;
    public Vector3 enemyForward;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //calculo el vector de movimiento desde enemy a player
        enemySeeDirection = (playerTarget.transform.position - transform.position).normalized;
        //valido que el angulo entre el forward del enemy y el player esta dentro del rango de vision del enemy
        angulo = Vector3.Angle(transform.forward, enemySeeDirection);
        enemyForward = transform.forward;
        magnitud = transform.forward.magnitude;
        if (Vector3.Angle(transform.forward, enemySeeDirection) <= enemyViewAngle)
        {
            //emulo un rayo desde la posicion del enemy hasta el player
            eneySeePlayer = Physics.Raycast(transform.position, enemySeeDirection, out hit, enemySeeMaxDistance);
        }



    }
}
