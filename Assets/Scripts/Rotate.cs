using UnityEngine;

public class Rotate : MonoBehaviour
{
    // Declare speed of rotation
    public float rotationSpeed = 1.0f;

    // Update is called once per frame
    void Update()
    {
        // Apply rotation
        transform.Rotate(0, rotationSpeed, 0);
    }
}
