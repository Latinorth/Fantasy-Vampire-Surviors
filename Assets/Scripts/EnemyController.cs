using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    public Rigidbody2D enemyRb;
    private GameObject player;
    private Vector2 movement;
    public int health;

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
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController playerController = gameObject.GetComponent<PlayerController>();
            playerController.health -= 1;
        }
    }
}
        

