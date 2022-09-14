using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Effects : MonoBehaviour
{

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
