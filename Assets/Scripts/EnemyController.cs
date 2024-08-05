using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class EnemyController : MonoBehaviour
{
    public float speed;
    public Rigidbody2D enemyRb;
    public GameObject player;
    public int health;
    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        playerController = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //movement = player.transform.position - transform.position.normalized;
        //enemyRb.MovePosition(enemyRb.position + movement * speed);
        Vector2 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRb.MovePosition(enemyRb.position + speed * Time.fixedDeltaTime * lookDirection);
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerController.health -= 1;
        }
    }
}


