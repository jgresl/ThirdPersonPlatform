using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float score = 0;

    // A reference for our input manager
    [SerializeField] private InputManager inputManager;

    [SerializeField] private TextMeshProUGUI scoreText;

    private void Start()
    {

    }

    private void IncrementScore()
    {
        score++;
        scoreText.text = $"Score: {score}";
    }
}