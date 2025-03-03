using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    public UnityEvent<Vector3> OnMove = new UnityEvent<Vector3>();
    public UnityEvent<Vector3> OnJump = new UnityEvent<Vector3>();
    private bool onGround = true;
    private int currentJump = 1;
    private int maxJumps = 2;

    // Move parameters visible to component
    [SerializeField] private float jumpInput;
    [SerializeField] private float speedInput;
    [SerializeField] private CinemachineCamera freeLookCamera;

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


        // Create a 3D version of the 2D input vector
        Vector3 inputXZPlane = new Vector3(inputVector.x, 0, inputVector.y);

        // Get the rotation angle from the free-look camera
        var cameraRotation = Quaternion.Euler(0, freeLookCamera.transform.rotation.eulerAngles.y, 0);

        if (onGround)
        {
            // Send the input data to the OnMove event
            OnMove?.Invoke(cameraRotation * inputXZPlane * speedInput);
        } else
        {
            // Reduce air control
            OnMove?.Invoke(cameraRotation * inputXZPlane * speedInput * 0.5f);
        }


        if (Input.GetButtonDown("Jump"))
        {
            // BONUS - Implement double jump feature
            if (currentJump <= maxJumps)
            {
                currentJump++;
                onGround = false;

                // Create a 3D input vector for applying jump force
                Vector3 inputYPlane = new Vector3(0, jumpInput, 0);

                // Send the input data to the OnMove event
                OnJump?.Invoke(cameraRotation * inputYPlane);

                if (currentJump == 2) {
                    // BONUS - Implment dash feature
                    OnMove?.Invoke(cameraRotation * inputXZPlane * speedInput * 2.0f);
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = true;
            currentJump = 1;    
        }
    }
}
