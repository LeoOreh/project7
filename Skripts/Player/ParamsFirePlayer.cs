using UnityEngine;

public class ParamsFirePlayer : MonoBehaviour
{
    // here we enter the goal to which we will approach
    GameObject aim;

    public float DAMAGE = 15;
    public float speed = 0.1f;
    public float lifetime = 3;                  // object lifetime
    float timer = 0;
    public float actualAfterTrigger = 0.2f;     // how long will be relevant after touching. this is to give time to finish effect PS
    public bool endForBonusPS;                          // whether to stop the PS effect. Always if there is.   DONT!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

    void Start()
    {
        // search target by tag
        aim = GameObject.FindGameObjectWithTag("EnemyAim");

        if (aim != null)
            // rotate the object to the target
            gameObject.transform.LookAt(aim.transform);
    }

    void FixedUpdate()
    {
        timer += 0.02f;
        // forward movement
        transform.Translate(Vector3.forward.normalized * speed);

        // destroy object if time is up
        if (timer >= lifetime)
            Destroy(gameObject);
    }

    // when touching an object, reduce the lifetime
    private void OnTriggerEnter(Collider other)
    {
        if (   other.tag != "Player" 
            && other.tag != "FireE"
            && other.tag != "FireP"
            && other.tag != "Reward"
            && other.tag != "Gate"
            && other.tag != "Coin")
           {
            
            if (endForBonusPS)
                // stop PS animation
                GetComponentInChildren<ParticleSystem>().Stop(true);
            else
                timer = lifetime - actualAfterTrigger;
        }

    }
}
