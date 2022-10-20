using UnityEngine;
using UnityEngine.SceneManagement;

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
        SceneManager.LoadScene(2);
    }
}
