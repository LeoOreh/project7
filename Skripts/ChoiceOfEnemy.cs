using UnityEngine;

// activating enemies and finding a target

public class ChoiceOfEnemy : MonoBehaviour
{
    // put all active enemies under the "Enemy" tag from the block.
    public GameObject[] arrayEnemyActive; 
    
    public GameObject targetForAtack;

    // target search frequency
    public float timer = 0.5f;
    // hand stopwatch
    public float TIME = 0;

    GameObject player;

    // circle at the bottom of the target for visual understanding
    public GameObject AimVisual;
    // and animation object with PS
    public GameObject AimVisualPS;
    // directly animation from PS
    ParticleSystem PS;
    // use material for smooth appearance "AimVisual"
    Material colorAimVisual;
    // degree of change per frame
    Color colorChange = new Color(0, 0, 0, 0.2f);

    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        PS = AimVisualPS.GetComponent<ParticleSystem>();
        colorAimVisual = AimVisual.GetComponentInChildren<Renderer>().material;
    }
    private void FixedUpdate()
    {
        // so that the number 1 is equal to one second
        TIME += 0.02f;

        if (timer <= TIME)
        {
            // attack target has a unique tag
            targetForAtack = GameObject.FindGameObjectWithTag("EnemyAim");
            if (targetForAtack == null)
            {
                // if there is no object with a unique tag for the target, then assign it to any enemy

                GameObject activatorEnemyAim = GameObject.FindGameObjectWithTag("Enemy");
                if (activatorEnemyAim != null)
                activatorEnemyAim.tag = "EnemyAim";
            }

            // search for active enemies. they should be all enemies on the block. and only they
            arrayEnemyActive = GameObject.FindGameObjectsWithTag("Enemy");
            if (targetForAtack != null && arrayEnemyActive != null)
            {
                float targetDistance = Vector3.Distance(player.transform.position, targetForAtack.transform.position);

                // checking all enemies
                for (int i = 0; i < arrayEnemyActive.Length; i++)
                {
                    // looking for distance to the enemy
                    float distanceToTheEnemy = Vector3.Distance(player.transform.position, arrayEnemyActive[i].transform.position);

                    // if the enemy is closer than the active target, then change the target to the nearest enemy
                    if (distanceToTheEnemy < targetDistance)
                    {
                        targetForAtack.tag = "Enemy";
                        arrayEnemyActive[i].tag = "EnemyAim";
                        player.GetComponent<PlayerController>().enemyAim = GameObject.FindGameObjectWithTag("EnemyAim");
                    }
                }
            }

            TIME = 0;
        }


        if (targetForAtack != null)
        {       
            // smoothly change the visual object of the target
            AimVisual.transform.position = Vector3.Lerp(AimVisual.transform.position, targetForAtack.transform.position, 0.1f);

            // smooth appearance of a visual object
            if (colorAimVisual.color.a < 0.7f)
                colorAimVisual.color += colorChange;

            // activation PS
            if (PS.isPlaying == false)
                PS.Play(true);
        }
        else
        {
            // visual object fading
            if (colorAimVisual.color.a > 0)
            {
                colorAimVisual.color -= colorChange;
                PS.Stop(true);
            }
        }
    }
}
