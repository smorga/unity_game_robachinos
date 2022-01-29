using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public int lifePlayer = 100;
    public string playerName = "noname";
    public float speedPlayer = 1f;
    public Vector3 direction;
    public float size = 1f;
    public int ContinuosHealing = 1;
    public int Damage1 = 1;




    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   //PlayerHealing(ContinuosHealing);
        //PlayerDamage(Damage1);
        //Debug.Log(lifePlayer);
        PlayerMovement(direction);
        transform.localScale += new Vector3 ( size, size, size ) * speedPlayer * Time.deltaTime;
        
    }
    void PlayerMovement(Vector3 direction2)
    {transform.Translate(speedPlayer * Time.deltaTime * direction2);
    }
    void PlayerHealing (int healingAmount)
    { lifePlayer += healingAmount;
    }
    void PlayerDamage (int DamageAmount)
    { lifePlayer -= DamageAmount;
    }
}
