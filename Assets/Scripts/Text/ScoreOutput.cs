using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreOutput : MonoBehaviour
{
    public GameObject player;
    public Text score;
    void Update()
    {
        score.text = $"{player.GetComponent<CoinsPickup>()._coinsPickedUp}";
    }
}
