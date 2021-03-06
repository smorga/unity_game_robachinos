using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    //animacion
    [SerializeField] Animator PlayerAnimator;
    [SerializeField] float DeathInterval;
    private bool TemporizadorParaMuerte;
    public float TiempoDeMuerte;
    [SerializeField] GameObject playerSeePoint;

    [SerializeField] GameObject puDoor;
    [SerializeField] GameObject puLight;
    private bool DoorOpen = false;
    private float DoorDistance = 0.6f;
    private float DoorAcumDistance = 0f;
    private bool playerCanSeePuDoor;
    private bool playerCanSeePuLight;
    [SerializeField] float playerSeeDistance=2f;

    // Start is called before the first frame update
    void Start()
    {

    }
    private void FixedUpdate()
    {
        PlayerSeePuDoor();
        PlayerSeePuLight();
    }
    void Update()
    {
        //corre temporizador de cámara cuando se inicie
        TemporizadorCamara();
        //Vuelve camara luego de agotado el temporizador
        CamaraOriginal();
        //apertura de puerta
        OpenDoor();
        //temporizador de luces
        TemporizadorLuces();
        LucesOn();
        TemporizadorMuerte();

        //nueva condicion del raycast para validar si el player ve el PU

    }




    private void OpenDoor()
    {
        if (DoorOpen == true)
        {
            if (DoorAcumDistance <= DoorDistance)
            {
                DoorLeft.transform.position += Vector3.forward * Time.deltaTime;
                DoorRight.transform.position += Vector3.back * Time.deltaTime;
                DoorAcumDistance += Vector3.back.magnitude * Time.deltaTime;
            }
        }
    }

    private void OnCollisionStay(Collision other)
    {

        {

            //si está tocando el powerup y toca space
            if (other.gameObject.CompareTag("PU OpenDoor") && Input.GetKeyDown(KeyCode.Space)
                && playerCanSeePuDoor == true)
            {
                CambioCamara();
                //Metodo de apertura de puerta
                DoorOpen = true;
                Destroy(puDoor);
            }
            if (other.gameObject.CompareTag("PU LightsOff") && Input.GetKeyDown(KeyCode.Space)
                && playerCanSeePuLight == true)

            {
                LucesOff();

            }
        }


    }
    private void PlayerSeePuDoor()
    {

        if (Physics.Raycast(playerSeePoint.transform.position - playerSeePoint.transform.forward, playerSeePoint.transform.forward, out RaycastHit hitDoor, playerSeeDistance)
                && hitDoor.collider.gameObject == puDoor)
        {
            playerCanSeePuDoor = true;
        }
        else
        {
            playerCanSeePuDoor = false;
        }
    }
    private void PlayerSeePuLight()
    {
        if (Physics.Raycast(playerSeePoint.transform.position - playerSeePoint.transform.forward, playerSeePoint.transform.forward, out RaycastHit hitLight, playerSeeDistance)
                && hitLight.collider.gameObject == puLight)
        {
            playerCanSeePuLight = true;
        }
        else
        {
            playerCanSeePuLight = false;
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
        luzGeneral.SetActive(false);
        luzWin.SetActive(true);
        GetComponent<Player>().playerCanMove = false;
        PlayerAnimator.SetBool("IsRun", false);
        TemporizadorParaMuerte = true;


        //SceneManager.LoadScene("1.Supermercado");
    }
    private void PlayerDie()
    {

        Debug.Log("GAME OVER");
        luzGeneral.SetActive(false);
        luzGameOver.SetActive(true);
        GetComponent<Player>().playerCanMove = false;

        PlayerAnimator.SetBool("IsDeath", true);
        TemporizadorParaMuerte = true;

    }
    private void TemporizadorMuerte()
    {
        if (TiempoDeMuerte > DeathInterval)
        {
            SceneManager.LoadScene("1.Supermercado");
            TemporizadorParaMuerte = false;
        }
        if (TemporizadorParaMuerte == true)
        {
            TiempoDeMuerte += Time.deltaTime;

        }
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
        if (temporizadorCamara == true)
        {
            tiempoCambioCamara += Time.deltaTime;
        }

    }
    private void CamaraOriginal()
    {
        if (tiempoCambioCamara >= tiempoEsperaCamara)
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
    }

    private void LucesOff()
    {
        //apaga las luces
        luzGeneral.SetActive(false);
        temporizadorLuces = true;
    }
    private void LucesOn()
    {
        if (timerLucesOff >= tiempoLucesOff)
        {
            luzGeneral.SetActive(true);
            timerLucesOff = 0;
            temporizadorLuces = false;
        }
    }
    private void TemporizadorLuces()
    {
        if (temporizadorLuces == true)
        {
            timerLucesOff += Time.deltaTime;
        }
    }


}
