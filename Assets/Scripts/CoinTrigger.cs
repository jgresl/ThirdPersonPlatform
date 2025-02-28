using UnityEngine;
using UnityEngine.Events;

public class CoinTrigger : MonoBehaviour
{
    public UnityEvent OnCoinCollect = new();
    private void OnCollisionEnter(Collision collision)
    {
        OnCoinCollect.Invoke();
        gameObject.SetActive(false);
    }
}
