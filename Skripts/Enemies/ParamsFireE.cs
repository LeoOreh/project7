using UnityEngine;

public class ParamsFireE : MonoBehaviour
{
    GameObject player;

    public float damage = 15;  // object touch damage
    public float speed = 0.1f;
    public float lifetime = 3;  // object lifetime
    float timer;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        // rotate the object towards the target
        gameObject.transform.LookAt(player.transform);
    }

    void FixedUpdate()
    {
        timer += 0.02f;
        if (timer >= lifetime)
            Destroy(gameObject);

        // move forward
        transform.Translate(Vector3.forward.normalized * speed);
    }

    // destruction on touch
    private void OnTriggerEnter(Collider other)
    {
        if (   other.tag != "Enemy" 
            && other.tag != "EnemyAim" 
            && other.tag != "FireP" 
            && other.tag != "Coin")
            Destroy(gameObject);

    }
}
