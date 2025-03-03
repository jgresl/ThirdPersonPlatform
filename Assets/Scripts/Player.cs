using UnityEngine;
public class Player : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;

    private Rigidbody rb;

    private void Start()
    {
        // Adding MovePlayer as a listener to the OnMove and OnJump events
        inputManager.OnMove.AddListener(MovePlayer);
        inputManager.OnJump.AddListener(JumpPlayer);
        rb = GetComponent<Rigidbody>();
    }

    private void MovePlayer(Vector3 moveDirection)
    {
        rb.AddForce(moveDirection, ForceMode.Force);
    }

    private void JumpPlayer(Vector3 jumpDirection)
    {
        Debug.Log("Jump Player");
        rb.AddForce(jumpDirection, ForceMode.Impulse);
    }
}