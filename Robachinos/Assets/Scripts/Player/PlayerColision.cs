using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColision : MonoBehaviour
{

    [SerializeField] float tiempoCambioCamara = 0f;
    [SerializeField] float tiempoEsperaCamara = 2f;
    public GameObject CameraControllerObject;

    private bool temporizadorCamara = false;
    [SerializeField] GameObject luzGeneral;
    [SerializeField] GameObject luzTubos;
    [SerializeField] GameObject luzGameOver;
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
            //cambio de camara
            CameraControllerObject.GetComponent<Cameras>().activateCamera(1, false);
            CameraControllerObject.GetComponent<Cameras>().activateCamera(0, true);
            //apaga las luces
            luzGeneral.SetActive(false);
            luzTubos.SetActive(false);
            //resetea temporizador y lo apaga
            tiempoCambioCamara = 0;
            temporizadorCamara = false;
            //restaura movimiento del player
            GetComponent<Player>().playerCanMove = true;
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
            //frena movimiento del player
            GetComponent<Player>().playerCanMove = false;

        }
    }
    private void OnCollisionEnter(Collision other)
    {
        //Debug.Log(name + " COLISION CON " + other.gameObject.name);
        if (other.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("GAME OVER");
            Destroy(gameObject);
            luzGeneral.SetActive(false);
            luzTubos.SetActive(false);
            luzGameOver.SetActive(true);
        }
    }
}
