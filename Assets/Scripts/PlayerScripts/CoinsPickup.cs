using System.Collections.Generic;
using UnityEngine;

public class CoinsPickup : MonoBehaviour
{
    public int _coinsPickedUp;

    private void Start()
    {
        _coinsPickedUp = PlayerPrefs.GetInt("Score");
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("coin"))
        {
            col.gameObject.SetActive(false);
            ++_coinsPickedUp;
        }

        if (col.gameObject.CompareTag("Finish"))
        {
            PlayerPrefs.SetInt("Score", _coinsPickedUp);
        }

        if (col.gameObject.CompareTag("lastFinish"))
        {
            PlayerPrefs.SetInt("Score", 0);
            if (PlayerPrefs.HasKey("playerName"))
            {
                for (int i = 0; i < 10; i++)
                {
                    //inserts record
                    if (PlayerPrefs.HasKey($"Score{i}"))
                    {
                        if (PlayerPrefs.GetInt($"Score{i}") < _coinsPickedUp)
                        {
                            for (int j = 9; j > i; j--)
                            {
                                if (PlayerPrefs.HasKey($"Score{j - 1}"))
                                {
                                    PlayerPrefs.SetInt($"Score{j}", PlayerPrefs.GetInt($"Score{j - 1}"));
                                    PlayerPrefs.SetString($"playerName{j}",
                                        PlayerPrefs.GetString($"playerName{j - 1}"));
                                }
                            }

                            PlayerPrefs.SetInt($"Score{i}", _coinsPickedUp);
                            PlayerPrefs.SetString($"playerName{i}", PlayerPrefs.GetString("playerName"));
                            break;
                        }
                    }
                    //add new record
                    else
                    {
                        PlayerPrefs.SetInt($"Score{i}", _coinsPickedUp);
                        PlayerPrefs.SetString($"playerName{i}", PlayerPrefs.GetString("playerName"));
                        break;
                    }
                }
            }
        }
    }
}