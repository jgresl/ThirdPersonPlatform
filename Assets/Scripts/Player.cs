using UnityEngine;
public class Player : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] private float speed;

    private Rigidbody rb;

    private void Start()
    {
        // Adding MovePlayer as a listener to the OnMove event
        inputManager.OnMove.AddListener(MovePlayer);
        rb = GetComponent<Rigidbody>();
    }

    private void MovePlayer(Vector3 moveDirection)
    {
        rb.AddForce(speed * moveDirection);
    }
}