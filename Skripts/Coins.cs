using UnityEngine;
using UnityEngine.UI;

public class Coins : MonoBehaviour
{
    public int coins;
    public Text coinsText;

    // if the player collides with an object under the "coin" tag

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Coin")
        {
            coins += other.GetComponent<CoinValue>().value;

            // display
            coinsText.GetComponent<Text>().text = "" + coins;
        }
    }

    public void CoinsPlus(float value)
    {
        coins += (int) value;
        print("+ " + value + " coins.... = " + coins);

        // display
        coinsText.GetComponent<Text>().text = "" + coins;
    }
 }
