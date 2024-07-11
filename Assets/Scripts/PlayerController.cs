using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public int health;
    public float moveSpeed = 5f;
    private Rigidbody2D Playerrb;
    private Vector2 movement;
    private Animator animator;


    public Animation up;
    public Animation down;
    public Animation left;
    public Animation right;
    public Animation idle;

    public bool upBool;
    public bool downBool;
    public bool leftBool;
    public bool rightBool;
    public bool idleBool;

    // Start is called before the first frame update
    void Start()
    {
        Playerrb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        movement.y = Input.GetAxisRaw("Vertical");
        movement.x = Input.GetAxisRaw("Horizontal");


        if (movement.x != 0 || movement.y != 0)
        {

            animator.SetFloat("X", movement.x);
            animator.SetFloat("Y", movement.y);

            animator.SetBool("IsWalking", true);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }


        if (movement.y == 1)
        {
            upBool = true;
            downBool = false;
        }
        else if (movement.y == -1)
        {
            downBool = true;
            upBool = false;
        }
        else if (movement.x == 1)
        {
            rightBool = true;
            leftBool = false;
        }
        else if (movement.x == -1)
        {
            leftBool = true;
            rightBool = false;
        }
        else if(movement.y == 0 && movement.x == 0)
        {
            idleBool = true;
            upBool = false;
            downBool = false;
            rightBool = false;
            leftBool = false;
        }



        Playerrb.MovePosition(Playerrb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("You Lose :(");
        }
    }
}
