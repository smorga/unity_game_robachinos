using System.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float Speed = 1.0f;
    [SerializeField] Vector3 Direction = new Vector3 (1 , 0 , 0);
    [SerializeField] int Damage = 80;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        BulletMovement(Direction);
    }
    void BulletMovement(Vector3 ParameterDirection)
    {
        transform.Translate(Speed * Time.deltaTime * ParameterDirection);

    }
}
