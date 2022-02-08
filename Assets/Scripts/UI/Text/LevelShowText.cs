using UnityEngine;

public class LevelShowText : MonoBehaviour
{
    private float _savedStartTime;
    void Start()
    {
        _savedStartTime = Time.time;
    }
    void Update()
    {
        if (Time.time - _savedStartTime > 2)
        {
            gameObject.SetActive(false);
        }
    }
}
