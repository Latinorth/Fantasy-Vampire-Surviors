using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public Rigidbody2D enemyRb;
    private GameObject player;
    private Vector2 movement;
    public float playerx;
    public float playery;
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //movement = player.transform.position - transform.position.normalized;
        //enemyRb.MovePosition(enemyRb.position + movement * speed);
        Vector2 lookDirection = (player.transform.position - transform.position);
        enemyRb.MovePosition(enemyRb.position + lookDirection * speed);

        playerx = player.transform.position.x;
        playery = player.transform.position.y;
    }
}
