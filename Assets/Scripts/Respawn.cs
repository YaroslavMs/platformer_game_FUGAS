using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject spawn;
    public GameObject checkpoint;
    private bool _checkpointActivated = false;
    void Start()
    {
        transform.position = spawn.transform.position;
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("DeathCollider"))
        {
            if (!_checkpointActivated)
                transform.position = spawn.transform.position;
            else
                transform.position = checkpoint.transform.position;
        }

        if (col.gameObject.CompareTag("Checkpoint"))
        {
            _checkpointActivated = true;
        }
    }

   
}
