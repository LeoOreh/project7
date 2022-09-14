using UnityEngine;

// choose which bonus. choose only one

public class Bonus : MonoBehaviour
{
    public bool coinsBonus;

    public bool healthBomus;

    public bool speedDSDownBonus;

    public float bonusValue = 0;

    GameObject player;
    GameObject objectDS;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        if(speedDSDownBonus)
            objectDS = GameObject.FindGameObjectWithTag("Block");
    }

    // trigger bonus activation
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (coinsBonus)
            {
                player.GetComponent<Coins>().coins += (int) bonusValue;
            }

            if (healthBomus)
            {
                // add health
                player.GetComponent<LifePlayer>().health += bonusValue;
                // but not more than the maximum
                if (player.GetComponent<LifePlayer>().health > player.GetComponent<LifePlayer>().healthMax)
                    player.GetComponent<LifePlayer>().health = player.GetComponent<LifePlayer>().healthMax;
            }

            if (speedDSDownBonus)
            {
                // objectDS.GetComponent<DeadlyShadow>().speedBonus += value;
            }
        }
    }
}
