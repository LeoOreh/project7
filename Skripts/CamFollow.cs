using UnityEngine;

// the camera follows the player

public class CamFollow : MonoBehaviour
{
    public GameObject player;
    public float y = 7;
    public float z;
    public float distanceToPlayer = 7;
    private void Start()
    {
        z -= distanceToPlayer;
    }
    void FixedUpdate()
    {
        // smooth change of values
        z += (player.transform.position.z - z) / 10;
        transform.position = new Vector3(0, y, z- distanceToPlayer);
    }
}
