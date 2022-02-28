using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemywaypoints : MonoBehaviour
{

    public Transform[] waypoints;
    public float speed;
    public int currentindex;
    public float minimunDistance;
    public bool goback;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement();
        
    }
    void movement()
    {
        var deltaVector = waypoints[currentindex].position - transform.position;
        var direction = deltaVector.normalized;

        transform.position += direction * speed * Time.deltaTime;
        transform.LookAt(waypoints[currentindex]);


        if (deltaVector.magnitude <= minimunDistance) 
        {
            if (currentindex >= waypoints.Length - 1)
            {
                goback = true;
            }
            else if (currentindex <= 0)
            { goback = false;
            }
            
            
            if (goback)
            { currentindex--;
            }
            else currentindex++;

        }





    }
}
