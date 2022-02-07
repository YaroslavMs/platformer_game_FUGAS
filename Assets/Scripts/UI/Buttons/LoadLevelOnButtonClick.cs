using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevelOnButtonClick : MonoBehaviour
{
    public string levelName;

    public void LoadLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(levelName);
    }
}
