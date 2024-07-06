using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class greatswordscript : MonoBehaviour
{

    public float radius;
    public float thetaTime;
    public float swordSpeed;
    public float swordRotationSpeed = Mathf.PI/18;


    private Rigidbody2D rb;
    private Vector2 movement;

    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //GetPlayerRb = otherGameObject.GetComponent<Playerrb>();
        //GetPlayerRb = Playerrb;
        //Rigidbody2D Playerrb
    }

    // Update is called once per frame
    void Update()
    {
        thetaTime = swordSpeed * (float)Time.timeAsDouble + Mathf.PI/6;
        //movement.x = moveSpeed * Mathf.Pow(Mathf.Sin(2 * theta), 0.5f) * Mathf.Pow(Mathf.Sin(theta), 0.1f) * Mathf.Cos(theta);
        //movement.y = moveSpeed * Mathf.Pow(Mathf.Sin(2 * theta), 0.5f) * Mathf.Pow(Mathf.Sin(theta), 0.1f) * Mathf.Sin(theta);
        movement.y = radius * Mathf.Sin(thetaTime);
        movement.x = radius * Mathf.Cos(thetaTime);

        transform.position = (Vector2)player.position + movement;
        transform.Rotate(0, 0, swordRotationSpeed);
    }
}
