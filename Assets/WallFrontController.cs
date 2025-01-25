using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallFrontController : MonoBehaviour
{
    Player player;
    Camera mainCamera;
    GameObject lastWall;

    void Start()
    {
        this.player = GameObject.Find("Player").GetComponent<Player>();
        this.mainCamera = Camera.main;
    }

    void Update()
    {
        // Ensure the camera is orthographic
        if (!mainCamera.orthographic)
        {
            Debug.LogWarning(
                "The camera is not orthographic. This script is designed for orthographic cameras."
            );
            return;
        }

        // Calculate the direction from the camera to the player in the camera's forward direction
        Vector3 cameraToPlayer = player.transform.position - mainCamera.transform.position;
        Vector3 rayDirection = mainCamera.transform.forward; // Orthographic camera's forward direction

        // Calculate the distance along the camera's forward axis
        float distance = Vector3.Dot(cameraToPlayer, rayDirection);

        // Cast a ray from the camera to the player
        RaycastHit hit;
        if (Physics.Raycast(mainCamera.transform.position, rayDirection, out hit, distance))
        {
            Debug.Log(
                "Hit object: " + hit.collider.gameObject.name + " " + hit.collider.gameObject.tag
            );
            // Check if the hit object has the "WallFront" tag
            if (hit.collider.CompareTag("WallFront"))
            {
                // Disable the MeshRenderer of the wall
                MeshRenderer wallRenderer = hit.collider.GetComponent<MeshRenderer>();
                if (wallRenderer != null)
                {
                    wallRenderer.enabled = false;
                    lastWall = hit.collider.gameObject; // Store the last wall
                }
            }
            else if (lastWall != null)
            {
                // Re-enable the MeshRenderer of the last wall if it's no longer in the way
                MeshRenderer lastWallRenderer = lastWall.GetComponent<MeshRenderer>();
                if (lastWallRenderer != null)
                {
                    lastWallRenderer.enabled = true;
                }
                lastWall = null; // Reset the last wall
            }
        }
        else if (lastWall != null)
        {
            // Re-enable the MeshRenderer of the last wall if nothing is hit
            MeshRenderer lastWallRenderer = lastWall.GetComponent<MeshRenderer>();
            if (lastWallRenderer != null)
            {
                lastWallRenderer.enabled = true;
            }
            lastWall = null; // Reset the last wall
        }
    }

    // Optional: Visualize the ray in the Scene view
    private void OnDrawGizmos()
    {
        if (mainCamera != null && player != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(
                mainCamera.transform.position,
                mainCamera.transform.position
                    + mainCamera.transform.forward
                        * Vector3.Dot(
                            player.transform.position - mainCamera.transform.position,
                            mainCamera.transform.forward
                        )
            );
        }
    }
}
