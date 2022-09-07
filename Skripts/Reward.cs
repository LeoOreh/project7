using UnityEngine;

public class Reward : MonoBehaviour
{
    public GameObject cube;                        // cube award. when the enemy dies, the desired object returns here
    Material cubeEffect;                           // for the fade effect
    Color plusColor = new Color(0, 0, 0, 0.03f);

    GameObject player;

    public GameObject[] arrayPS;                   // array of particle system effects
    public bool destruction = false;               // whether to destroy the object

    GameObject instantiateCube;
    public bool limitTime = false;               // whether the object is limited by time
    public float timelife = 3;              // object lifetime

    public GameObject PSFlash;                     // explosion effect. at the expiration of the lifetime

    public float ValueReward = 3;
    float timer = 0;


    void Start()
    {
        if (cube) 
        {
            instantiateCube = Instantiate(cube, transform);
            cubeEffect = instantiateCube.GetComponent<Renderer>().material;
        }
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {
        // if transparent - reduce transparency
        if (cubeEffect.color.a < 0.9f && destruction == false)
            cubeEffect.color += plusColor;

        timer += 0.02f;

        // delay the time of the collision trigger
        if (timer >= 0.5f)
            GetComponent<BoxCollider>().enabled = true;

        if (limitTime)
        {

            if (timer >= timelife)
            {
                // create an explosion object
                GameObject flash = Instantiate(PSFlash);
                flash.transform.position = gameObject.transform.position;

                Destroy(gameObject);
            }
        }
        Destruction();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            // stop all particle system effects
            for (int i = 0; i < arrayPS.Length; i++)
            {
                arrayPS[i].GetComponent<ParticleSystem>().Stop(true);
            }

            // enable object destruction
            destruction = true;
            limitTime = false;
        }
    }
    void Destruction()
    {
        if (destruction)
        {
            // creating a magnetizing effect
            instantiateCube.transform.position = Vector3.Lerp(instantiateCube.transform.position, player.transform.position, 0.06f);
            // make transparent
            if (cubeEffect.color.a > 0)
                cubeEffect.color -= plusColor;
            else Destroy(gameObject);
        }
    }
}
