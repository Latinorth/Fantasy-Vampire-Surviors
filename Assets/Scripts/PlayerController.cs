using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D Playerrb;
    private Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        Playerrb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // Get input from arrow keys or WASD
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Move the player
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
