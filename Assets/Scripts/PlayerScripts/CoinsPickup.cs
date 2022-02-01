using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class CoinsPickup : MonoBehaviour
{
    public int _coinsPickedUp;
    public int level = 1;

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
                    
                    if (PlayerPrefs.HasKey($"Score{i}"))
                    {
                        if (_coinsPickedUp > PlayerPrefs.GetInt($"Score{i}"))
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
