using UnityEngine;

public class RevolveBlade : MonoBehaviour
{
    public float rotationSpeed = 100f; // Speed of rotation in degrees per second

    void Update()
    {
        // Rotate the fan around its Y-axis (or change to the correct axis for your fan)
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}
