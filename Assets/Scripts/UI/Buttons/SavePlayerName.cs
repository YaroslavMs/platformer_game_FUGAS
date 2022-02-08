using UnityEngine;
using UnityEngine.UI;

public class SavePlayerName : MonoBehaviour
{
    public Text playerName;
    public Text savedName;

    public void Start()
    {
        if (PlayerPrefs.HasKey("playerName"))
        {
            savedName.text = PlayerPrefs.GetString("playerName");
        }
    }

    public void OnButtonClick()
    {
        if(playerName.text != "")
            PlayerPrefs.SetString("playerName", playerName.text);
    }

}
