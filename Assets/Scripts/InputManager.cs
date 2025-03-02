using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    public UnityEvent<Vector3> OnMove = new UnityEvent<Vector3>();
    private bool onGround = true;
    public float jumpInput = 50f;

    [SerializeField] private CinemachineCamera freeLookCamera;

    // Update is called once per frame
    void Update()
    {
        // Intialize the 2D input vector
        Vector2 inputVector = Vector2.zero;

        // Get user input
        if (Input.GetKey(KeyCode.W) && onGround)
        {
            inputVector += Vector2.up;
        }
        if (Input.GetKey(KeyCode.S) && onGround)
        {
            inputVector += Vector2.down;
        }
        if (Input.GetKey(KeyCode.D) && onGround)
        {
            inputVector += Vector2.right;
        }
        if (Input.GetKey(KeyCode.A) && onGround)
        {
            inputVector += Vector2.left;
        }

        float jump = 0f;
        if (Input.GetKey(KeyCode.Space) && onGround)
        {
            jump = jumpInput;
            onGround = false;
        }

        // Create a 3D version of the 2D input vector
        Vector3 inputXZPlane = new Vector3(inputVector.x, jump, inputVector.y);

        // Get the rotation angle from the free-look camera
        var cameraRotation = Quaternion.Euler(0, freeLookCamera.transform.rotation.eulerAngles.y, 0);

        // Send the input data to the OnMove event
        OnMove?.Invoke(cameraRotation * inputXZPlane);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = true;
        }
    }
}
