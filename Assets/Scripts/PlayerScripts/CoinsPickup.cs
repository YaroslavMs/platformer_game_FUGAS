using UnityEngine;
using UnityEngine.Serialization;

public class CoinsPickup : MonoBehaviour
{
    [FormerlySerializedAs("_coinsPickedUp")]
    public int coinsPickedUp;
    
    private void Start()
    {
        enemy_behaviour.MobIsDead += KilledMob;
        coinsPickedUp = PlayerPrefs.GetInt("Score");
    }

    private void KilledMob(string a)
    {
        if (a == "boss")
        {
            coinsPickedUp += 50;
        }

        if (a == "normal")
        {
            coinsPickedUp += 5;
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("coin"))
        {
            col.gameObject.SetActive(false);
            ++coinsPickedUp;
        }

        else if (col.gameObject.CompareTag("Finish"))
        {
            PlayerPrefs.SetInt("Score", coinsPickedUp);
        }

        else if (col.gameObject.CompareTag("lastFinish"))
        {
            PlayerPrefs.SetInt("Score", 0);
            if (PlayerPrefs.HasKey("playerName"))
            {
                SaveRecord();
            }
        }
    }

    private void SaveRecord()
    {
        for (int i = 0; i < 10; i++)
        {
            //inserts record
            if (PlayerPrefs.HasKey($"Score{i}"))
            {
                if (coinsPickedUp > PlayerPrefs.GetInt($"Score{i}"))
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

                    PlayerPrefs.SetInt($"Score{i}", coinsPickedUp);
                    PlayerPrefs.SetString($"playerName{i}", PlayerPrefs.GetString("playerName"));
                    break;
                }
            }
            //add new record
            else
            {
                PlayerPrefs.SetInt($"Score{i}", coinsPickedUp);
                PlayerPrefs.SetString($"playerName{i}", PlayerPrefs.GetString("playerName"));
                break;
            }
        }
    }
}