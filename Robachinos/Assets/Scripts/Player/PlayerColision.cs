using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColision : MonoBehaviour
{
    //variables camara
    private float tiempoCambioCamara = 0f;
    [SerializeField] float tiempoEsperaCamara = 2f;
    public GameObject CameraControllerObject;
    private bool temporizadorCamara = false;
    //luces
    [SerializeField] GameObject luzGeneral;
    [SerializeField] GameObject luzGameOver;
    [SerializeField] GameObject luzWin;
    [SerializeField] GameObject DoorLeft;
    [SerializeField] GameObject DoorRight;
    private float timerLucesOff = 0f;
    [SerializeField] float tiempoLucesOff = 10f;
    private bool temporizadorLuces = false;

    private bool DoorOpen = false;
    [SerializeField] float DoorDistance = 10f;
    private float DoorAcumDistance = 0f;
    // animator
    [SerializeField] float deathInterval = 5;    
    [SerializeField] Animator playerAnimator;
    // Start is called before the first frame update
    void Start()
    {

    }
    void Update()
    {
        //corre temporizador de cámara cuando se inicie
        if (temporizadorCamara == true)
        {
            TemporizadorCamara();
        }
        //Vuelve camara luego de agotado el temporizador
        if (tiempoCambioCamara >= tiempoEsperaCamara)
        {
            CamaraOriginal();
        }
        //apertura de puerta
        if (DoorOpen == true)
        {
            OpenDoor();
        }
        //temporizador de luces
        if (temporizadorLuces == true)
        {
            TemporizadorLuces();
        }
        if (timerLucesOff >= tiempoLucesOff)
        {
            LucesOn();
        }
    }




    private void OpenDoor()
    {
        if (DoorAcumDistance <= DoorDistance)
        {
            DoorLeft.transform.position += Vector3.forward * Time.deltaTime;
            DoorRight.transform.position += Vector3.back * Time.deltaTime;
            DoorAcumDistance += Vector3.back.magnitude * Time.deltaTime;
        }
    }

    private void OnCollisionStay(Collision other)
    {
        //si está tocando el powerup y toca space
        if (other.gameObject.CompareTag("PU OpenDoor") && Input.GetKeyDown(KeyCode.Space))
        {
            CambioCamara();
            //Metodo de apertura de puerta
            DoorOpen = true;
        }
        if (other.gameObject.CompareTag("PU LightsOff") && Input.GetKeyDown(KeyCode.Space))
        {
            LucesOff();
            
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

    private void PlayerWin()
    {
        Debug.Log("WIN");
        Destroy(gameObject);
        luzGeneral.SetActive(false);
        luzWin.SetActive(true);

    }

    private void PlayerDie()
    {
        Debug.Log("GAME OVER");
        playerAnimator.SetBool("IsDeath", true);
        Destroy(gameObject,deathInterval);
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
        GetComponent<Player>().playerAnimator.SetBool("IsRun", false);
    }
    private void TemporizadorCamara()
    {
        tiempoCambioCamara += Time.deltaTime;
    }
    private void CamaraOriginal()
    {
        //cambio de camara
        CameraControllerObject.GetComponent<Cameras>().activateCamera(0, true);
        CameraControllerObject.GetComponent<Cameras>().activateCamera(1, false);
        //resetea temporizador y lo apaga
        tiempoCambioCamara = 0;
        temporizadorCamara = false;
        //restaura movimiento del player
        GetComponent<Player>().playerCanMove = true;
    }

    private void LucesOff()
    {
        //apaga las luces
        luzGeneral.SetActive(false);
        temporizadorLuces = true;
    }
    private void LucesOn()
    {
        luzGeneral.SetActive(true);
        timerLucesOff = 0;
        temporizadorLuces = false;
    }
    private void TemporizadorLuces()
    {
        timerLucesOff += Time.deltaTime;
    }


}
