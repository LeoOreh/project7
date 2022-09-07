using UnityEngine;

//  all objects are divided into blocks. on each block,
//  a script is installed with the control of the enemies of this block.

public class EnemyController : MonoBehaviour
{
    //  place all enemies from the block
    public GameObject[] Enemies;

    // Fog visual effect - ParticleSystem.
    public GameObject PSFog;                              


    // trigger on block entry
    private void OnTriggerEnter(Collider other)
    {
        //the trigger works only on the player through the check for the tag
        if (other.tag == "Player")
        {
            //stop visual fog effect
            PSFog.GetComponent<ParticleSystem>().Stop(true);

            //through the loop we activate the enemies through the activation of the script
            for (int i = 0; i < Enemies.Length; i++)
            {
                Enemies[i].GetComponent<EnemyActControl>().enabled = true;

                //and change the enemy tag
                if (Enemies[i].tag == "EnemyOFF") Enemies[i].tag = "Enemy";               
            }
            //disable this trigger on this block
            GetComponent<BoxCollider>().enabled = false;
        }
    }
}
