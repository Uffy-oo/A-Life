using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player; // Player's transform
    public float smoothSpeed = 0.125f; // Adjust this value to change how smoothly the camera follows the player
    public float zoomOutSize = 5f; // Camera size for showing the whole screen (zoomed out)
    public float zoomInSize = 3f; // Camera size when the player is moving (zoomed in)

    private Vector3 offset; // Offset between camera and player position
    private Camera cam; // Reference to the camera component

    void Start()
    {
        cam = GetComponent<Camera>();

        // Automatically find the Student_0 GameObject and get its transform
        GameObject studentGameObject = GameObject.Find("Student_0");
        if (studentGameObject != null)
        {
            player = studentGameObject.transform;
        }
        // else
        // {
        //     Debug.LogError("Student_0 not found. Please assign the Player in the inspector.");
        //     return;
        // }

        offset = transform.position - player.position;
    }

    void LateUpdate()
    {
        if (player == null) return;

        Vector3 desiredPosition = player.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        if (PlayerIsMoving())
        {
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, zoomInSize, smoothSpeed);
        }
        else
        {
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, zoomOutSize, smoothSpeed);
        }
    }

    bool PlayerIsMoving()
    {
        // Check if the player's velocity is greater than a small threshold
        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            return rb.velocity.magnitude > 0.1f;
        }
        return false;
    }
}

// public class CameraController : MonoBehaviour
// {
//     Transform target;
//     Vector3 velocity = Vector3.zero;


//     [Range(0,1)]
//     public float smoothTime;

//     public Vector3 positionOffset;

//     private void Awake(){
//         target = GameObject.FIndGameObjectWithTag("Student_0").transform;
//     }

//     private void LateUpdate(){
//         Vector3 targetPosition = target.position + positionOffset;
//         transform.position= Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
//     }
// }
