using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishCollision : MonoBehaviour
{
    public string nextSceneName;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Finish"))
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
