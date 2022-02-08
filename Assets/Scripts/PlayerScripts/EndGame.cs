using UnityEngine;

public class EndGame : MonoBehaviour
{
    public GameObject WinMenu;

    private void Start()
    {
        WinMenu.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("lastFinish"))
        {
            Time.timeScale = 0;
            WinMenu.SetActive(true);
        }
    }
}
