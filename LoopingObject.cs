using UnityEngine;

public class LoopingObject : MonoBehaviour
{
    public float speed = 5f; // Kecepatan gerakan
    public Transform cameraTransform; // Referensi ke kamera
    public float offsetLeft = -10f; // Offset batas kiri relatif terhadap kamera
    public float offsetRight = 10f; // Offset titik awal relatif terhadap kamera

    void Update()
    {
        // Gerakkan objek ke kiri
        transform.position += Vector3.left * speed * Time.deltaTime;

        // Hitung batas kiri dan kanan berdasarkan posisi kamera
        float leftBoundary = cameraTransform.position.x + offsetLeft;
        float rightStart = cameraTransform.position.x + offsetRight;

        // Jika melewati batas kiri, reset ke posisi kanan relatif terhadap kamera
        if (transform.position.x < leftBoundary)
        {
            ResetPosition(rightStart);
        }
    }

    void ResetPosition(float newRightPosition)
    {
        transform.position = new Vector3(newRightPosition, transform.position.y, transform.position.z);
    }
}
