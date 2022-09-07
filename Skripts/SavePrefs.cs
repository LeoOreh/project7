using UnityEngine;

// Testing save

public class SavePrefs : MonoBehaviour
{
    public float coin_ToSave;
    float coin_load;

    public GameObject player;

    public void ProcessSaved()
    {
        coin_ToSave = player.GetComponent<Coins>().coins;
        print("collected coins " + coin_ToSave);
        LoadGame();
        print("загружаем + " + coin_load);
        coin_ToSave += coin_load;
        SaveGame();
        LoadGame();
        print("загружаем + " + coin_load);
    }

    void SaveGame()
    {
        PlayerPrefs.SetFloat("SavedInteger", coin_ToSave);
        PlayerPrefs.Save();
        Debug.Log("Game data saved!");
    }
    void LoadGame()
    {
        if (PlayerPrefs.HasKey("SavedInteger"))
        {
            coin_load = PlayerPrefs.GetFloat("SavedInteger");
            Debug.Log("Game data loaded!");
        }
        else
            Debug.LogError("There is no save data!");
    }
}
