using UnityEngine;

public class CoinsRewardPlus : MonoBehaviour
{
    Component scriptREWARD;
    bool once = false;                // logic for one
    public GameObject PSCoinsPlus;   // effect of taking
    GameObject Player;
    GameObject ps;                    // created effect of taking
    public float Value = 3;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        // get information from parents
        scriptREWARD = GetComponentInParent<Reward>();
        Value = GetComponentInParent<Reward>().ValueReward;
    }


    void FixedUpdate()
    {
        // trigger check
        if (!once && scriptREWARD.GetComponent<Reward>().destruction == true)
        {
            // this logic will no longer be executed
            once = true;
            // directly changing the value
            Player.GetComponent<Coins>().CoinsPlus(Value);
        }
        else
        {
            if (once && PSCoinsPlus)
            {
                ps = Instantiate(PSCoinsPlus);
                PSCoinsPlus = null;
                // delayed deletion
                Destroy(ps, 3);
            }
        }

        //the effect follows the player
        if (ps)
            ps.transform.position = Player.transform.position;
    }
}
