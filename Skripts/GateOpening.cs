using UnityEngine;

// script of various effects and actions

public class GateOpening : MonoBehaviour
{

    public GameObject gate1;
    public GameObject gate2;
    float x = 0;
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && x < 3)
        {
            gate1.transform.position += new Vector3(0.1f, 0);
            gate2.transform.position -= new Vector3(0.1f, 0);
            x += 0.1f;
        }
    }
}
