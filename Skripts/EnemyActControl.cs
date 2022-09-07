using UnityEngine;


public class EnemyActControl : MonoBehaviour
{
    GameObject player;

    public bool ATACK = true;
    float timerAtack = 0;
    public float timeAtack = 2;

    // always look at the player
    public bool lookAtPlayer = true;
    // smoothness of turn
    public float smoothTurn = 10;

    Animator animator;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        animator = this.GetComponent<Animator>();
    }
    void FixedUpdate()
    {
        timerAtack += 0.02f;

        TURN();

        FIRE();
    }



    //-------------------------------------------------------------------------

    // smooth turn

    Quaternion q1;
    Quaternion q2;
    void TURN()
    {
        if (lookAtPlayer)
        {
            // rotation 1
            q1 = transform.rotation;

            // turn towards the target
            transform.LookAt(player.transform);

            // rotation 2
            q2 = transform.rotation;

            // smooth change between two rotations over a period of time
            transform.rotation = Quaternion.Lerp(q1, q2, Time.deltaTime * smoothTurn);
        }
    }
    //-------------------------------------------------------------------------


    // launch beams to search for obstacles.

    // the result from the ray is placed here. The first object in the path of the beam
    RaycastHit hit;

    // prefab to attack
    public GameObject firePrefab;

    // animation time before attack
    public float timeForAnimThrow = 0.2f;

    void FIRE()
    {
        // let the beam reach the target
        Ray ray = new Ray(transform.position, player.transform.position - transform.position);
        Physics.Raycast(ray, out hit);

        // if the tag matches, we attack. the target itself can be an object. or an object to be ignored
        if (   hit.collider.gameObject == player.gameObject 
            || hit.collider.gameObject.tag == "FireP" 
            || hit.collider.gameObject.tag == "Reward" 
            || hit.collider.gameObject.tag == "decay" 
            || hit.collider.gameObject.tag == "Coin")
        {
            // pre-attack animation
            if (timerAtack >= timeAtack - timeForAnimThrow)
                animator.SetBool("throw", true);

           if (timerAtack >= timeAtack && ATACK)
           {
                // create an object of attack
                GameObject newObjectFire = Instantiate(firePrefab);

                // place the object of attack on the attacker
                newObjectFire.transform.position = gameObject.transform.position;

                timerAtack = 0;
                animator.SetBool("throw", false);
            }

            // draw beam in editor
            Debug.DrawLine(ray.origin, hit.point, Color.red);
        }
    }
    //-------------------------------------------------------------------------

}
