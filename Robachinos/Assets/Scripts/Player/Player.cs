using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int lifePlayer = 100;
<<<<<<< HEAD
    [SerializeField] float speedPlayer = 2f;
=======
    [SerializeField] float speedPlayerMove = 4f;
    [SerializeField] float speedPlayerRotate = 2f;
>>>>>>> copyjuly
    [SerializeField] Vector3 direction;
    [SerializeField] float size = 1f;
    [SerializeField] int continuosHealing = 1;
    [SerializeField] int damage1 = 1;
<<<<<<< HEAD

=======
    [SerializeField] private Animator playerAnimator;
    public bool playerCanMove = true;
    float cameraAxisX = 0f;
>>>>>>> copyjuly
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            PlayerMovement(Vector3.left);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            PlayerMovement(Vector3.right);
        }
=======
        if (playerCanMove == true)
        {
            PlayerInputMove();
            PlayerRotate();
        }

    }
    //Movimiento del player
    private void PlayerInputMove()
    {
>>>>>>> copyjuly
        if (Input.GetKey(KeyCode.UpArrow))
        {
            PlayerMovement(Vector3.forward);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            PlayerMovement(Vector3.back);
        }

    }
    //Movimiento del player
    private void PlayerMovement(Vector3 direction2)
    {
        transform.Translate(speedPlayer * Time.deltaTime * direction2);
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
