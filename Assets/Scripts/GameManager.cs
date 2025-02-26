using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float score = 0;
    [SerializeField] private TextMeshProUGUI scoreText;

    private void IncrementScore()
    {
        score++;
        scoreText.text = $"Score: {score}";
    }
}