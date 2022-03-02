using System.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 5f;
    
    [SerializeField] int Damage = 80;

    [SerializeField] float destroyTime = 3f;

    private float destroyClock = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        BulletMovement(Vector3.forward);
        
        destroyClock += Time.deltaTime;
        if(destroyClock >= destroyTime)
        {
            Destroy(gameObject);
        }
        
    }
    private void BulletMovement(Vector3 ParameterDirection)
    {
        transform.Translate(bulletSpeed * Time.deltaTime * ParameterDirection);

    }

}
