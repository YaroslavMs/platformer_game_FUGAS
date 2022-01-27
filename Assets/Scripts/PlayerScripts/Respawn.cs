using UnityEngine;

public class Respawn : MonoBehaviour
{
    public int currentLife;
    public GameObject[] hearts;
    public GameObject spawn;
    public GameObject checkpoint;
    private bool _checkpointActivated = false;
    private float _savedTime;
    void Start()
    {
        currentLife = 3;
        transform.position = spawn.transform.position + new Vector3(0,0.5f,0);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("DeathCollider") && Time.time - _savedTime > 0.001)
        {
            _savedTime = Time.time;
            currentLife--;
            hearts[currentLife].SetActive(false);
            if (!_checkpointActivated)
                transform.position = spawn.transform.position + new Vector3(0,0.5f,0);
            else
                transform.position = checkpoint.transform.position;
        }

        else if (col.gameObject.CompareTag("Checkpoint"))
        {
            _checkpointActivated = true;
        }
    }

   
}
