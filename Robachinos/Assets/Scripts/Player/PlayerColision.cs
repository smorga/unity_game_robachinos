using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColision : MonoBehaviour
{

    [SerializeField] float tiempoCambioCamara = 0f;
    [SerializeField] float tiempoEsperaCamara = 2f;
    public GameObject CameraControllerObject;
    
    private bool temporizadorCamara = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //corre temporizador de cámara
        if (temporizadorCamara == true)
        {
            tiempoCambioCamara += Time.deltaTime;
        }
        //Vuelve camara luego de agotado el temporizador
        if (tiempoCambioCamara >= tiempoEsperaCamara)
        {
            CameraControllerObject.GetComponent<Cameras>().activateCamera(1, false);
            CameraControllerObject.GetComponent<Cameras>().activateCamera(0, true);
            tiempoCambioCamara = 0;
            temporizadorCamara = false;
            GetComponent<Player>().playerCanMove=true;
        }
    }
    private void OnCollisionStay(Collision other)
    {
        //si está tocando el powerup y toca space
        if (other.gameObject.CompareTag("PowerUp") && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("ACCION QUE CAMBIA LA CAMARA Y ABRE LA PUERTA");
            //Cambio de cámara
            CameraControllerObject.GetComponent<Cameras>().activateCamera(0, false);
            CameraControllerObject.GetComponent<Cameras>().activateCamera(1, true);
            //Inicio de temporizador
            temporizadorCamara = true;
            GetComponent<Player>().playerCanMove=false;
        }
        
        

    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(name + " TRIGGER CON " + other.gameObject.name);

    }


}
