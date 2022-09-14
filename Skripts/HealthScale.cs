using UnityEngine;
using UnityEngine.UI;


public class HealthScale : MonoBehaviour
{
    float timerAim = 0;                  // timer to update goals
    float timerHealthEnd = 0;            // health digit transparency timer
    public float updateHealthAim = 1;    // how often to update

    GameObject aimE;                     // enemy whose value is shown

    public Image healthScaleE;           // scale image

    public float Health;                 // output value
    public float indexHealth;            // scale percentage value


    string textHealth;
    Color textColor;

    float yVelocity = 0.0f;

    private void Start()
    {
        aimE = GameObject.FindGameObjectWithTag("EnemyAim");
        if (aimE != null)
            indexHealth = aimE.GetComponent<LifeEnemy>().indexHealth;
        textColor = new Color(0, 0, 0, 0.065f);
    }
    void FixedUpdate()
    {
        // UPDATE Aim
        timerAim += 0.02f;
        if (timerAim >= updateHealthAim)
        {
            aimE = GameObject.FindGameObjectWithTag("EnemyAim");
            timerAim = 0;
        }

        // if there is a goal
        if (aimE != null)
        {
            // take the percentage of the health bar
            indexHealth = aimE.GetComponent<LifeEnemy>().indexHealth;

            // and a health number to display
            Health = aimE.GetComponent<LifeEnemy>().HEALTH;

            // smooth scale change
            healthScaleE.GetComponent<Image>().fillAmount = Mathf.SmoothDamp(healthScaleE.GetComponent<Image>().fillAmount, indexHealth, ref yVelocity, 0.5f);

            if (Health >= 0)
            {
                if (GetComponentInChildren<Text>().text == "")
                    GetComponentInChildren<Text>().text = "" + Health;

                // smooth value change
                textHealth = GetComponentInChildren<Text>().text;
                GetComponentInChildren<Text>().text = "" + Mathf.Round(Mathf.Lerp(float.Parse(textHealth), Health, 0.5f));
            }
            /*else
            {
                textHealth = GetComponentInChildren<Text>().text;
                GetComponentInChildren<Text>().text = "" + Mathf.Round( Mathf.Lerp(float.Parse(textHealth),Health, 0.5f));
      
            }*/
        }
        // if there is no target, then gradually lower the value to zero
        else
        {
            if (healthScaleE.GetComponent<Image>().fillAmount > 0)
                healthScaleE.GetComponent<Image>().fillAmount -= 0.2f;

        }
        // and if the value is zero, then disappear color
        if (Health == 0)
        {
            if (GetComponentInChildren<Text>().color.a > 0)
                GetComponentInChildren<Text>().color -= textColor;

            timerHealthEnd += 0.02f;
            if (timerHealthEnd > 0.15f)
            {
                // clearing the text to bring back the color later
                GetComponentInChildren<Text>().text = "";
                timerHealthEnd = 0;
                Health = 1.00001f;
            }
        }
        // color return
        if (Health == 1.00001f)
        {
            GetComponentInChildren<Text>().color = new Color(1, 1, 1, 1);

        }
    }
}
