using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    // Start is called before the first frame update
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log(name + " COLISION CON " + other.gameObject.name);
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("GAME OVER");
        }

        if (other.gameObject.CompareTag("Ground"))
        {
            gameObject.GetComponent<PlayerMovement>().SetJumpStatus(true);
        }
    }

    private void OnCollisionExit(Collision other)
    {
        Debug.Log(name + " EXIT COLISION CON " + other.gameObject.name);
        if (other.gameObject.CompareTag("Ground"))
        {
            gameObject.GetComponent<PlayerMovement>().SetJumpStatus(false);
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(name + " Tigger con" + other.gameObject.name);
        Destroy(other.gameObject);
    }

    //Al trabajar con un characterController este es el único método disponible para detectar colisiones.
    private void OnControllerColliderHit(ControllerColliderHit hit) {
        //Se ejecuta cada framme
        Debug.Log(name + " COLISION CON " + hit.gameObject.name);
        if (hit.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("GAME OVER");
        }
    }
}
