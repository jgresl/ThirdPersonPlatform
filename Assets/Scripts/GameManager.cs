using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float score = 0;
    [SerializeField] private TextMeshProUGUI scoreText;
    private CoinTrigger[] coins;

    private void Start()
    {
        coins = FindObjectsByType<CoinTrigger>(FindObjectsSortMode.None);
        foreach (CoinTrigger coin in coins)
        {
            coin.OnCoinCollect.AddListener(IncrementScore);
        }
    }

    private void IncrementScore()
    {
        score++;
        scoreText.text = $"Score: {score}";
    }
}