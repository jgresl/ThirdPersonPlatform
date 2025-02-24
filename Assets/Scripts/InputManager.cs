using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    public UnityEvent<Vector3> OnMove = new UnityEvent<Vector3>();
    private bool onGround = true;

    // Update is called once per frame
    void Update()
    {
        // Intialize the 2D input vector
        Vector2 inputVector = Vector2.zero;

        // Get user input
        if (Input.GetKey(KeyCode.W))
        {
            inputVector += Vector2.up;
        }
        if (Input.GetKey(KeyCode.S))
        {
            inputVector += Vector2.down;
        }
        if (Input.GetKey(KeyCode.D))
        {
            inputVector += Vector2.right;
        }
        if (Input.GetKey(KeyCode.A))
        {
            inputVector += Vector2.left;
        }

        float jump = 0f;
        if (Input.GetKey(KeyCode.Space) && onGround)
        {
            jump = 60f;
            onGround = false;
        }

        // Create a 3D version of the 2D input vector
        Vector3 inputXZPlane = new Vector3(inputVector.x, jump, inputVector.y);

        // Send the input data to the OnMove event
        OnMove?.Invoke(inputXZPlane);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Ground")
        {
            onGround = true;
            Debug.Log("Landed");
        }
    }
}
