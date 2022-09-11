using UnityEngine;

public class LifeE : MonoBehaviour
{
    public float FillHealth = 60;     // maximum value
    public float HEALTH;              // variable
    public float indexHealth;         // percentage of current health to maximum

    public GameObject PS;             // fade animation. outgoing smoke
    float t = 0;                      // code delay per second
    public GameObject body;           // fade person
    public GameObject createReward;   // prefab reward. after destruction. shell only!!!
    public GameObject rewards;        // contents of the reward
    public bool timerReward = false;  // limitation of existence by time. after the expiration of time - destroyed
    public float ValueReward = 5;     // reward value
    private void Start()
    {
        // the game starts with the maximum value. full health
        HEALTH = FillHealth;
    }
    private void FixedUpdate()
    {
        // if there is no health (by tag). destruction with effect
        if (tag == "EnemyEnd")
        {
            // make it transparent
            if (body.GetComponent<Renderer>().material.color.a > 0)
            body.GetComponent<Renderer>().material.color -= new Color(0, 0, 0, 0.03f);

            t += 0.02f;
            // create a reward through time
            if (t >= 1 && createReward)
            {
                GameObject In =  Instantiate(createReward);            // create a reward shell
                In.transform.position = gameObject.transform.position; // change the position of the reward to the position of the enemy object
                In.GetComponent<Reward>().cube = rewards;              // create the content of the reward
                In.GetComponent<Reward>().limitTime = timerReward;   // whether the existence of the reward is limited in time
                In.GetComponent<Reward>().ValueReward = ValueReward;   // assign a reward value to the object itself
                Destroy(gameObject);                                   // destroy the enemy object. should already be completely transparent.
            }
        }
        
        indexHealth =  HEALTH / FillHealth;            // percentage of health. for the health bar. it has values from 0 to 1.

        // if health =0. change the tag to destroy the object
        if (HEALTH <= 0)
        {
            tag = "EnemyEnd";
            PS.SetActive(true);     // outgoing smoke
        }
    }


    // damage trigger
    private void OnTriggerEnter(Collider other)
    {
        // player damage objects has the tag
        if (other.tag == "FireP")
        {
            HEALTH -= other.GetComponent<ParamsFireP>().DAMAGE;
            if (HEALTH < 0)
                HEALTH = 0;
            // disable this trigger
            other.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
