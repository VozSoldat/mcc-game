using UnityEngine;

public class CameraFollow: MonoBehaviour{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset; // Offset kamera dari target

    private void Start() {
        offset = transform.position-target.position;
    }

    void LateUpdate() {
        if (target == null) {Debug.LogError("target is null"); return;}
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}