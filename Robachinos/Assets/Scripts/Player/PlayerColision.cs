using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColision : MonoBehaviour
{

    [SerializeField] float tiempoCambioCamara = 0f;
    [SerializeField] float tiempoEsperaCamara = 2f;
    public GameObject CameraControllerObject;
    private bool temporizadorCamara = false;
    //luces
    [SerializeField] GameObject luzGeneral;

    [SerializeField] GameObject luzGameOver;
    [SerializeField] GameObject DoorLeft;
    [SerializeField] GameObject DoorRight;
    private bool DoorOpen = false;
    [SerializeField] float DoorDistance = 10f;
    public float DoorAcumDistance = 0f;
    // Start is called before the first frame update
    void Start()
    {

    }
    void Update()
    {
        //corre temporizador de cámara cuando se inicie
        if (temporizadorCamara == true)
        {
            Temporizador();
        }
        //Vuelve camara luego de agotado el temporizador
        if (tiempoCambioCamara >= tiempoEsperaCamara)
        {
            CamaraOriginal();
        }
        if (DoorOpen == true)
        {
            OpenDoor();
        }

    }

    private void OpenDoor()
    {
        if (DoorAcumDistance <= DoorDistance)
        {
            DoorLeft.transform.position += Vector3.forward * Time.deltaTime;
            DoorRight.transform.position += Vector3.back * Time.deltaTime;
            DoorAcumDistance += Vector3.back.magnitude*Time.deltaTime;
        }
    }

    private void OnCollisionStay(Collision other)
    {
        //si está tocando el powerup y toca space
        if (other.gameObject.CompareTag("PowerUp") && Input.GetKeyDown(KeyCode.Space))
        {
            CambioCamara();
            //Metodo de apertura de puerta
            DoorOpen = true;
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        //si al player lo toca una bullet
        if (other.gameObject.CompareTag("Bullet"))
        {
            PlayerDie();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Door"))
        {
            //win action
            PlayerWin();
        }
    }

    private static void PlayerWin()
    {
        Debug.Log("WIN");
    }

    private void PlayerDie()
    {
        Debug.Log("GAME OVER");
        Destroy(gameObject);
        luzGeneral.SetActive(false);
        luzGameOver.SetActive(true);
    }
    private void CambioCamara()
    {
        Debug.Log("ACCION QUE CAMBIA LA CAMARA Y ABRE LA PUERTA");
        //Cambio de cámara
        CameraControllerObject.GetComponent<Cameras>().activateCamera(1, true);
        CameraControllerObject.GetComponent<Cameras>().activateCamera(0, false);
        //Inicio de temporizador
        temporizadorCamara = true;
        //frena movimiento del player
        GetComponent<Player>().playerCanMove = false;
    }
    private void Temporizador()
    {
        tiempoCambioCamara += Time.deltaTime;
    }
    private void CamaraOriginal()
    {
        //cambio de camara
        CameraControllerObject.GetComponent<Cameras>().activateCamera(0, true);
        CameraControllerObject.GetComponent<Cameras>().activateCamera(1, false);

        //apaga las luces
        luzGeneral.SetActive(false);
        //resetea temporizador y lo apaga
        tiempoCambioCamara = 0;
        temporizadorCamara = false;
        //restaura movimiento del player
        GetComponent<Player>().playerCanMove = true;
    }
}
