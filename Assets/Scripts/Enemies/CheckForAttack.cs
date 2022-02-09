using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForAttack : MonoBehaviour
{
    public GameObject attack;
    private float _savedTime;
    private float _bossPause;

    public delegate void Attack(bool at);

    public event Attack AttackPerforming;
    public bool boss;

    private void Update()
    {
        if (Time.time - _savedTime >  0.4)
        {
            AttackPerforming?.Invoke(false);
             _savedTime = 0;
        }

        if (_savedTime == 0)
        {
            attack.SetActive(false);
        }
        
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player") && _savedTime == 0 && Time.time - _bossPause > 3)
        {
            AttackPerforming?.Invoke(true);
            attack.SetActive(true);
            _savedTime = Time.time;
            if (boss)
                _bossPause = Time.time;
        }
    }
}
