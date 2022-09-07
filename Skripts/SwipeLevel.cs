using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// in developing

public class SwipeLevel : MonoBehaviour
{
    public Image[] ImageLevel;
    public Image levelActual;
    int number = 0;

    private void Start()
    {
        levelActual.GetComponent<Image>().sprite = ImageLevel[number].GetComponent<Image>().sprite;
    }

    bool buttonRight;
    public void ButtonRight()
    {
        if (number + 2 <= ImageLevel.Length)
        {
            number++;
            levelActual.GetComponent<Image>().sprite = ImageLevel[number].GetComponent<Image>().sprite;
            print(number);
        }
    }

    bool buttonLeft;
    public void ButtonLeft()
    {
        if(number > 0)
        {
            number--;
            levelActual.GetComponent<Image>().sprite = ImageLevel[number].GetComponent<Image>().sprite;
            print(number);
        }
    }

    public string[] nameScene;
    public void buttonPlay()
    {
        print(number);
        SceneManager.LoadScene(nameScene[number]);
    }

    public GameObject settigsWindow;
    public void buttonSettings()
    {
        settigsWindow.SetActive(true);
    }
    public void buttonSettClose()
    {
        settigsWindow.SetActive(false);
    }
}
