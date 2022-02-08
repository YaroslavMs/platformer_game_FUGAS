using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerView : MonoBehaviour
{
    public delegate void OnPlayerEnter(bool x, Transform player);

    public event OnPlayerEnter PlayerEntered;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            PlayerEntered?.Invoke(true, col.gameObject.transform);
            
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerEntered?.Invoke(false, other.gameObject.transform);
        }
    }
}
