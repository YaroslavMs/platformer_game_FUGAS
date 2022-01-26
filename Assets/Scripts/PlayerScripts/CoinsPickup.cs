using System;
using System.Collections;
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
    }
}
