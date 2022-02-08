using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class TriggerView : MonoBehaviour
{
    public GameObject enemy;
    public delegate void OnPlayerEnter(bool x, Transform player);

    public event OnPlayerEnter PlayerEntered;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            PlayerEntered?.Invoke(true, col.gameObject.transform);
            
        }
    }

    private void Update()
    {
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerEntered?.Invoke(false, other.gameObject.transform);
        }
    }
}
