using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusFire : MonoBehaviour
{
    public bool tornadoBool = false;
    public GameObject tornado;

    private void FixedUpdate()
    {
        
    }

    public void AdditionFire()
    {
        if (tornado)
        {
           GameObject newTornado = Instantiate(tornado);
            newTornado.transform.position = gameObject.transform.position;

            newTornado.GetComponent<ParamsFirePlayer>().speed = GetComponent<PlayerController>().prefabAtackObj.GetComponent<ParamsFirePlayer>().speed;
        }
    }
}
