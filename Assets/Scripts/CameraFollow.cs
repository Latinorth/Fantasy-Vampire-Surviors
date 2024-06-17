using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public Vector3 offset; // Offset between the player and the camera

    // Update is called once per frame
    void Update()
    {
            // Update the camera's position to match the player's position plus the offset
            transform.position = player.position + offset;
    }
}
