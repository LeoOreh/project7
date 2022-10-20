using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class ChooseLevel : MonoBehaviour
{
    public GameObject[] SetLevels;
    int setIndex = 0;
    public GameObject buttonLeft;
    public GameObject buttonRight;

    bool right = false;
    bool left = false;

    public float speedAnimation = 100;
    public float change = 0;
    float targetChange = 2000;

    public void ButtonLeft()
    {
        print("ButtonLeft");
        buttonRight.SetActive(true);
        left = true;
        setIndex --;

        if (setIndex <=0)
            buttonLeft.SetActive(false);
    }
    public void ButtonRight()
    {
        print("ButtonRight");
        buttonLeft.SetActive(true);
        right = true;
        setIndex ++;

        if (setIndex >= SetLevels.Length - 1)
            buttonRight.SetActive(false);
    }

    private void FixedUpdate()
    {
        if (right)
            Anim(-speedAnimation);
        if (left)
            Anim(speedAnimation);

        void Anim(float speedAnimation)
        {
            if (change < targetChange && change > -targetChange)
            {
                for (int i = 0; i < SetLevels.Length; i++)
                {
                    SetLevels[i].transform.position += new Vector3(speedAnimation, 0, 0);
                }
                change += speedAnimation;
            }
            else
            {
                right = false;
                left = false;
                change = 0;
            }
        }

    }

    public void OpenLevels()
    {
        SceneManager.LoadScene(2);
    }

    public void OpenMenu()
    {
        SceneManager.LoadScene(1);
    }

    public void StartLevel()
    {       
        int s = int.Parse ( gameObject.GetComponentInChildren<Text>().text);
        print(s);
        SceneManager.LoadScene(s + 2);
    }
}
