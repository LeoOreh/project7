using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LifeP : MonoBehaviour
{
    public float healthMax = 80;
    public float health;

    public bool gameOverBool = false;  // end of the game
    public GameObject gameOverImage;   // window after losing
    Color slowly = new Color(0, 0, 0, 0.02f);

    public GameObject scaleP;
    Image imageScale;
    float valueScale;                  // what percentage is the scale filled

    void Start()
    {
        Time.timeScale = 1;            // game starts at standard speed
        health = healthMax;
        imageScale = scaleP.GetComponent<Image>();
    }
    private void FixedUpdate()
    {
        GameOver();   // if the game is over
        Scale();      // scale value control
    }


    private void OnTriggerEnter(Collider other)
    {
        // taking damage on touch
        if (other.tag == "FireE")
        {
            // find out the damage from the object
            health -= other.GetComponent<ParamsFireE>().damage;

            // check if there is still health
            HealthNull();
        }
    }

    // check if there is still health
    public void HealthNull()
    {
        if (health <= 0)
        {
            health = 0;

            // disable control
            GetComponent<PlayerController>().enabled = false;

            // activate the game over window
            gameOverImage.SetActive(true);
            // to create a smooth appearance
            gameOverBool = true;
            // stop all activity
            Time.timeScale = 0;

            // preservation
            GetComponent<SavePrefs>().ProcessSaved();
        }
    }


    void Scale()
    {
        // to smoothly change the value
        valueScale = Mathf.Lerp(valueScale, health / healthMax, 0.1f);
        imageScale.fillAmount = valueScale;

        // display health text on the health bar
        scaleP.GetComponentInChildren<Text>().text = health + " / " + healthMax;
    }

    // method on a foreign object. Changing health through a third-party object
    public void HealthPlus(float value)
    {
        health += value;
        if (health > healthMax)
            health = healthMax;
    }


    void GameOver()
    {
        if (gameOverBool)
        {
            //  smooth appearance of an object
            if (gameOverImage.GetComponent<Image>().color.a < 1)
            gameOverImage.GetComponent<Image>().color += slowly;
        }
    }

    // button method. exit to the main menu of levels
    public void ButtonExit()
    {
        SceneManager.LoadScene("level");
    }

    // button method. level restart
    public void ButtonReplay()
    {       
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
