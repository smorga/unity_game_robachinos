using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{

    [SerializeField] public Transform[] waypoints;
    [SerializeField] public float speed;
    private int currentindex;
    [SerializeField] public float minimunDistance;
    private bool goback;
    [SerializeField] private Animator EnemyAnimator;





    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        WaypointMovement();

    }
    void WaypointMovement()
    {
        if (GetComponent<EnemySeePlayer>().enemySeePlayer == false)
        {
            var deltaVector = waypoints[currentindex].position - transform.position;
            var direction = deltaVector.normalized;
            
            EnemyAnimator.SetBool("IsRun", true);
            transform.position += direction * speed * Time.deltaTime;
            
            //Quaternion newRotation = Quaternion.LookRotation(transform.position - waypoints[currentindex].position);
            //transform.rotation = newRotation;
            transform.LookAt(waypoints[currentindex]);
            if (deltaVector.magnitude <= minimunDistance)
            {
                if (currentindex >= waypoints.Length - 1)
                {
                    goback = true;
                    EnemyAnimator.SetBool("IsRun", true);
                }
                else if (currentindex <= 0)
                {
                    goback = false;
                    EnemyAnimator.SetBool("IsRun", true);
                }
                if (goback)
                {
                    currentindex--;
                }
                else currentindex++;
            }
        }
        else
        {
            EnemyAnimator.SetBool("IsRun", false);
        }



    }
}
