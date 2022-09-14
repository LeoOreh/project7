using UnityEngine;

// DS - DeadlyShadow
// you must choose one option (either A or B or C). choose only one

public class DeadlyShadow : MonoBehaviour
{

    public bool fixedMotionDS = true;          // A  -  used only on object DS. fixed object movement
    public bool thisTriggerDS = false;         // B  -  means that this object is a trigger when touched with the DS. to change the speed of the DS
    public bool thisTriggerPlayer = false;     // C  -  means that this object is a trigger when touching the player object. to change the speed of the DS

    public float speedDS = 0.03f;
    public GameObject deadlyShadow;
    public float speedChange = 0.01f;

    // player touch damage to DS
    public bool Damage = true;              
    float damage = 1;

    private void FixedUpdate()
    {
        // fixed object movement
        if (fixedMotionDS)
            transform.position += Vector3.forward * speedDS ;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (fixedMotionDS)
        {

            // if the DS object collides with enemies, then the enemies change the tag for self-destruction
            if (other.tag == "Enemy" || other.tag == "EnemyAim" || other.tag == "EnemyOFF")
            {
                other.tag = "EnemyEnd";

                //disable the reward when self-destructing
                other.GetComponent<LifeEnemy>().createReward = null;
            }
        }

        // option B
        if (thisTriggerDS && other.tag == deadlyShadow.tag)
            // change DS speed
            deadlyShadow.GetComponent<DeadlyShadow>().speedDS = speedChange;

        // option C
        if (thisTriggerDS && thisTriggerPlayer && other.tag == "Player")
            // change DS speed
            deadlyShadow.GetComponent<DeadlyShadow>().speedDS = speedChange;

        DamageToach(other);
    }
    private void OnTriggerStay(Collider other)
    {
        DamageToach(other);
    }

    // trigger damage with DS
    void DamageToach(Collider other)
    {
        if (Damage && other.tag == "Player")
        {
            // damage 1% of max health
            damage = Mathf.Round(other.GetComponent<LifePlayer>().healthMax / 100);

            // but not less than 1
            if (damage < 1)
                damage = 1;

            // change the player's health
            other.GetComponent<LifePlayer>().health -= damage;

            // end the game if there is no health
            other.GetComponent<LifePlayer>().HealthNull();
        }
    }
}
