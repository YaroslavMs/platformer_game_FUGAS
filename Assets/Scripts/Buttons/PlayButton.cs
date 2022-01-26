using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public void ButtonClicked()
    {
        if (PlayerPrefs.HasKey("lastLevel"))
        {
            SceneManager.LoadScene(PlayerPrefs.GetString("lastLevel"));
        }
        else SceneManager.LoadScene("FirstLevel");
    }
}
