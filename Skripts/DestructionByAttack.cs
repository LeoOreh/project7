using UnityEngine;

// destruction of the object by enemies and the player if there are the required number of triggers

public class DestructionByAttack : MonoBehaviour
{
    // required number of attack triggers
    public float requiredAmount = 3;

    public float actualAmount = 0;

    private void OnTriggerEnter(Collider other)
    {
        // the trigger of the player's attack and the attacks of enemies are taken into account
        if (other.tag == "FireP" || other.tag == "FireE")
        {
            actualAmount++;
            if (actualAmount >= requiredAmount) 
            Destroy(gameObject);
        }

    }
}
