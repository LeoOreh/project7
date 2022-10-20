using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Effects : MonoBehaviour
{
    public GameObject background;
    public bool startEffect = false;
   public bool exitEffect = false;
    int numberSceneTarget = 0;

    Image imageBackgrnd;
    Color colorChange = new Color(0, 0, 0, 0.1f);

    void Start()
    {
        imageBackgrnd = background.GetComponent<Image>();
        if (startEffect)
        {
            background.SetActive(true);
            background.GetComponent<Image>().color = new Color(0, 0, 0, 1);
        }
    }

    void FixedUpdate()
    {
        if (startEffect)
        {
            imageBackgrnd.GetComponent<Image>().color -= colorChange;
            if (imageBackgrnd.color.a <= 0)
               {
                startEffect = false;
                background.SetActive(false);
               }
        }
        if (exitEffect)
        {
            background.SetActive(true);
            imageBackgrnd.GetComponent<Image>().color += colorChange;
            if(imageBackgrnd.color.a >= 1)
            {
                exitEffect = false;
                SceneManager.LoadScene(numberSceneTarget);
            }
        }
    }



    //--------------------------------------------------------------------------------------------
    Color lightMinus = new Color(0, 0, 0, 0.03f);
    public void LightMinus(Image Image)
    {
        Image.GetComponent<Image>().color -= lightMinus;
    }

    Color lightPlus = new Color(0, 0, 0, 0.03f);
    public void LightPlus(Image Image)
    {
        Image.GetComponent<Image>().color += lightMinus;
    }
}
