using UnityEngine;
using UnityEngine.UI;

public class ScoreOutput : MonoBehaviour
{
    public GameObject player;
    public Text score;

    void Start()
    {
        score.color = Color.white;
    }
    void Update()
    {
        
        score.text = $"{player.GetComponent<CoinsPickup>().coinsPickedUp}";
    }
}
