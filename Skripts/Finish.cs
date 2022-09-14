using UnityEngine;

public class Finish : MonoBehaviour
{
    public GameObject finish;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        finish.SetActive(true);
    }

    public void ButtonCloseWindowFinish()
    {
        finish.SetActive(false);
    }
}
