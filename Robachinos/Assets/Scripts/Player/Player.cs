using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int lifePlayer = 100;
    [SerializeField] float speedPlayerMove = 2f;
    [SerializeField] float speedPlayerRotate = 2f;
    [SerializeField] Vector3 direction;
    [SerializeField] int continuosHealing = 1;
    [SerializeField] int damage1 = 1;
    [SerializeField] private Animator playerAnimator;
    float cameraAxisX = 0f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PlayerInputMove();
        PlayerRotate();
    }
    //Movimiento del player
    private void PlayerInputMove()
    {

        if (Input.GetKey(KeyCode.UpArrow))
        {
            PlayerMovement(Vector3.forward);
            playerAnimator.SetBool("IsRun", true);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            PlayerMovement(Vector3.back);
            playerAnimator.SetBool("IsRun", true);
        }
        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            playerAnimator.SetBool("IsRun", false);
        }
    }
    //Traslacion
    private void PlayerMovement(Vector3 direction2)
    {
        transform.Translate(speedPlayerMove * Time.deltaTime * direction2);
    }

    //Rotacion
    private void PlayerRotate()
    {
        cameraAxisX += Input.GetAxis("Horizontal");
        Quaternion angulo = Quaternion.Euler(0f, cameraAxisX * speedPlayerRotate, 0f);
        transform.localRotation = angulo;
    }
    //Curacion y daño
    private void PlayerHealing(int healingAmount)
    {
        lifePlayer += healingAmount;
    }
    private void PlayerDamage(int damageAmount)
    {
        lifePlayer -= damageAmount;
    }
}
