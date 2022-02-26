using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float speed = 2f;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject shootPoint;
    [SerializeField] float cooldown = 2f;
    [SerializeField] private bool canShoot = true;
    [SerializeField] private float timePass = 0;
    [SerializeField] private Animator playerAnimator;
    private Vector3 velocidad;
    [SerializeField] private float gravedad = -9.81f;
    [SerializeField] private float altura = 10f;
    private bool canJump;
    private GameObject parentBullets;
    float cameraAxisX = 0f;
    private CharacterController ccPlayer;
    
    void Start()
    {
        parentBullets = GameObject.Find("DinamycBullets");
        ccPlayer = GetComponent<CharacterController>();

    }
    void Update()
    {
        MovePlayer();
        RotatePlaye();
        ShootPlayer();
        JumpPlayer();
        //GRAVEDA
        //ccPlayer.Move(Vector3.down * 5f * Time.deltaTime);
        velocidad.y += gravedad * Time.deltaTime;
        ccPlayer.Move(velocidad * Time.deltaTime);
        playerAnimator.SetBool("isJump", !ccPlayer.isGrounded);
    }

    private void JumpPlayer()
    {
        if (Input.GetKeyDown(KeyCode.Space) && ccPlayer.isGrounded)
        {
            //ccPlayer.Move(Vector3.up * speedJump);
            velocidad.y = Mathf.Sqrt(-altura * gravedad);
        }
    }

    public void SetJumpStatus(bool status)
    {
        canJump = status;
        playerAnimator.SetBool("isJump", !status);
    }

    private void ShootPlayer()
    {
        if (Input.GetKeyDown(KeyCode.E) && canShoot)
        {
            canShoot = false;
            playerAnimator.SetBool("isShoot", !canShoot);
            Invoke("DelayShoot", 1f);
        }

        if (!canShoot)
        {
            timePass += Time.deltaTime;
        }

        if (timePass > cooldown)
        {
            timePass = 0;
            canShoot = true;
            playerAnimator.SetBool("isShoot", !canShoot);
        }
    }

    private void DelayShoot()
    {
        GameObject newBullet = Instantiate(bulletPrefab, shootPoint.transform.position, transform.rotation);// PROYECTILES
        newBullet.transform.parent = parentBullets.transform;
    }

    private void MovePlayer()
    {
        if (Input.GetKey(KeyCode.W))
        {
            MovePlayer(Vector3.forward);
            playerAnimator.SetBool("isRun", true);
        }
        if (Input.GetKey(KeyCode.S))
        {
            MovePlayer(Vector3.back);
            playerAnimator.SetBool("isRun", true);
        }

        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
        {
            playerAnimator.SetBool("isRun", false);
        }
    }

    private void MovePlayer(Vector3 direction)
    {
        // transform.Translate();
        ccPlayer.Move(speed * Time.deltaTime * transform.TransformDirection(direction));
    }

    private void RotatePlaye()
    {
        //1 UN VALOR PARA ROTAR EN Y
        cameraAxisX += Input.GetAxis("Horizontal");
        //2 UN ANGULO A CALCULAR EN FUNCION DEL VALOR DEL PRIMER PASO
        Quaternion angulo = Quaternion.Euler(0f, cameraAxisX * 0.5f, 0f);
        //3 ROTAR
        transform.localRotation = angulo;
    }
}
