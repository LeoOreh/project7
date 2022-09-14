using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    float timer = 0;
    public float speedAtack = 1.5f;         // attack frequency in seconds
    public GameObject prefabAtackObj;      // than to attack

    public GameObject enemyAim;             // aim
    public float timeForAnimThrow = 0.2f;   // time for throw animation

    RaycastHit hit;                         // beam from the player to the target. returns an object here. if there are obstacles then do not attack.
    Ray ray;

    public GameObject energyScale;          // energy scale. recharge.
    Animator animator;                      // to manage animations

    private void Start()
    {
        animator = this.GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        timer += 0.02f;

        // cooldown bar percentage
        energyScale.GetComponent<Image>().fillAmount = timer / speedAtack;         

        if (enemyAim != null)
        {
            // beam in the direction of the target
            ray = new Ray(transform.position, enemyAim.transform.position - transform.position); 
            // returns an object in the path of the beam
            Physics.Raycast(ray, out hit);      

            // if you don't touch or press anything
            if (!Input.anyKey)
            {
                // for a smooth turn to the object
                SmooothTURN();
                ATTACK();
            }
             TimeForThrowAnimation();               
        }
        else
        {
            // target search
            enemyAim = GameObject.FindGameObjectWithTag("EnemyAim");
            TimeForThrowAnimation();
        }

        // if it's time for an animation before the attack
        void TimeForThrowAnimation()
        {
            if (Input.anyKey && timer > speedAtack - timeForAnimThrow)
            {
                timer = speedAtack - timeForAnimThrow;
                animator.SetBool("throw", false);
            }
            if (Input.anyKey)
            {
                animator.SetBool("throw", false);
            }
            if (!Input.anyKey && enemyAim != null)
                animator.SetBool("throw", true);
        }

        void ATTACK()
        {
            if (timer >= speedAtack)
            {
                // if there are no obstacles to the goal. But this is conditional. not finalized
                if (hit.collider.gameObject == enemyAim.gameObject
                 || hit.collider.gameObject.tag == "FireE"
                 || hit.collider.gameObject.tag == "Reward"
                 || hit.collider.gameObject.tag == "decay"
                 || hit.collider.gameObject.tag == "Coin")
                {
                    // create an object of attack and change the location
                    GameObject newObjectFire = Instantiate(prefabAtackObj);
                    newObjectFire.transform.position = gameObject.transform.position;

                    timer = 0;
                    animator.SetBool("throw", false);
                    // display attack damage
                    energyScale.GetComponentInChildren<Text>().text = newObjectFire.GetComponent<ParamsFirePlayer>().DAMAGE + "";
                }
            }
        }

        Quaternion q1;
        Quaternion q2;
        void SmooothTURN()
        {         
            q1 = transform.rotation;                              // find the corner of an object
            transform.LookAt(enemyAim.transform.position);        // rotate the object to the target
            q2 = transform.rotation;                              // target of the turn
            transform.rotation = Quaternion.Lerp(q1, q2, 10);     // smooth turn between two corners
        }
    }
}
