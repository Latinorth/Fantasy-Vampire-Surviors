using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class GreatSwordController : MonoBehaviour
{

    public float radius;
    public float thetaTime;
    public float swordSpeed;
    public float swordRotationSpeed = Mathf.PI/18;

    public int killed;
    public TextMeshProUGUI killedCanvas;

    private Vector2 movement;

    public Transform player;

    private EnemyController enemyController;

    // Update is called once per frame
    void Update()
    {
        thetaTime = swordSpeed * (float)Time.timeAsDouble + Mathf.PI/6;
        //movement.x = moveSpeed * Mathf.Pow(Mathf.Sin(2 * theta), 0.5f) * Mathf.Pow(Mathf.Sin(theta), 0.1f) * Mathf.Cos(theta);
        //movement.y = moveSpeed * Mathf.Pow(Mathf.Sin(2 * theta), 0.5f) * Mathf.Pow(Mathf.Sin(theta), 0.1f) * Mathf.Sin(theta);
        movement.y = radius * Mathf.Sin(2 * thetaTime) * Mathf.Sin(thetaTime);
        movement.x = radius * Mathf.Sin(2 * thetaTime) * Mathf.Cos(thetaTime);

        transform.position = (Vector2)player.position + movement;
        transform.Rotate(0, 0, swordRotationSpeed);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemyController = other.gameObject.GetComponent<EnemyController>();
            enemyController.health -= 1;
            if (enemyController.health < 0)
            {
                Destroy(other.gameObject);
                killed++;
                killedCanvas.text = "Greatsword: " + killed;
            }
        }
    }
}
