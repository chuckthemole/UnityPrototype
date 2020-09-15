using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLerpToTransform : MonoBehaviour {
    // The camera's target and speed
    public Transform target;
    public float speed;

    // Camera Bounds
    public float minX;
    public float minY;
    public float maxX;
    public float maxY;
    
    /*
     * Tracks player with Rigidbody2D component
     */
    void FixedUpdate() {
        if (target != null) // Check for valid transformation
        {
            var newPos = Vector2.Lerp(transform.position, target.position, Time.deltaTime * speed); // linear interpolation between two vectors by given value

            // Makes certain the position is in camera bounds
            var camPosition = new Vector3(newPos.x, newPos.y, -10f);
            var v3 = camPosition;
            var clampX = Mathf.Clamp(v3.x, minX, maxX);
            var clampY = Mathf.Clamp(v3.y, minY, maxY);
            transform.position = new Vector3(clampX, clampY + .15f, -10f);
        }
    }
}
