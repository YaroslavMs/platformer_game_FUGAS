using UnityEngine;

public class BackgroundMoving : MonoBehaviour
{
    public GameObject player;

    // Update is called once per frame
    private void LateUpdate()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, 0);
    }
}
