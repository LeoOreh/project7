using UnityEngine;

// object is destroyed when time expires

public class DestroyInTime : MonoBehaviour
{
    public float timeDistroy = 3f;
    void FixedUpdate()
    {
        Destroy(gameObject, timeDistroy);
    }
}
