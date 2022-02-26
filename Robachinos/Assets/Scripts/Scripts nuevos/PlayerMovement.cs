using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float speed = 2f;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject shootPoint;
    [SerializeField] float cooldown = 2f;
    [SerializeField] private bool canShoot = true;
    [SerializeField] private float timePass = 0;

    [SerializeField] private float speedJump = 1f;

    [SerializeField] private Animator playerAnimator;

    private bool canJump;

    private GameObject parentBullets;
    float cameraAxisX = 0f;

    void Start()
    {
        parentBullets = GameObject.Find("DinamycBullets");
        
    }
    void Update()
    {
        MovePlayer();
        RotatePlaye();
        ShootPlayer();
        JumpPlayer();

    }

    private void JumpPlayer()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            transform.Translate(Vector3.up * speedJump);
        }
    }

    public void SetJumpStatus(bool status){
        canJump = status;
        playerAnimator.SetBool("isJump", !status);
    }

    private void ShootPlayer()
    {
        if (Input.GetKeyDown(KeyCode.E) && canShoot)
        {
            canShoot = false;
            playerAnimator.SetBool("isShoot", !canShoot);
            Invoke("DelayShoot",1f);
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

        if(Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S)){
            playerAnimator.SetBool("isRun", false);
        }
    }

    private void MovePlayer(Vector3 directionEnemy)
    {
        transform.Translate(speed * Time.deltaTime * directionEnemy);
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
