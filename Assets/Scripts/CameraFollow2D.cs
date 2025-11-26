using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    public Transform target;    // El personaje a seguir
    public float smoothSpeed = 0.125f;  // Suavidad del movimiento
    public Vector3 offset;      // Distancia de la cámara al personaje

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, transform.position.z);
    }
}
