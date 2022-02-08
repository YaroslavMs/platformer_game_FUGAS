using UnityEngine;

public class Respawn : MonoBehaviour
{
    public int currentLife;
    public GameObject[] hearts;
    public GameObject spawn;
    public GameObject checkpoint;
    public Rigidbody2D rb;
    private bool _checkpointActivated = false;
    private float _savedTime;

    public delegate void PlayerDeath(bool a);

    public event PlayerDeath PlayerIsDead;

    void Start()
    {
        currentLife = 3;
        transform.position = spawn.transform.position + new Vector3(0, 0.5f, 0);
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("DeathCollider") && Time.time - _savedTime > 0.001)
        {
            _savedTime = Time.time;
            currentLife--;
            hearts[currentLife].SetActive(false);
            if (currentLife <= 0)
            {
                PlayerIsDead?.Invoke(true);
            }

            if (!_checkpointActivated)
                transform.position = spawn.transform.position + new Vector3(0, 0.5f, 0);
            else
                transform.position = checkpoint.transform.position;
        }
        else if (col.gameObject.CompareTag("Enemy") && Time.time - _savedTime > 0.6)
        {
            if (transform.position.x < col.gameObject.transform.position.x)
            {
                rb.AddForce(Vector2.right * -4, ForceMode2D.Impulse);
            }
            else if (transform.position.x > col.gameObject.transform.position.x)
            {
                rb.AddForce(Vector2.right * 4, ForceMode2D.Impulse);
            }

            _savedTime = Time.time;
            currentLife--;
            hearts[currentLife].SetActive(false);
            if (currentLife <= 0)
            {
                PlayerIsDead?.Invoke(true);
            }
        }

        else if (col.gameObject.CompareTag("Checkpoint"))
        {
            _checkpointActivated = true;
            checkpoint.transform.Find("a").GetComponent<Renderer>().material.SetColor("_Color", Color.magenta);
        }
    }
}