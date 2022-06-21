using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        if (GameManager.instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        SceneManager.sceneLoaded += LoadState;
        DontDestroyOnLoad(gameObject);
    }

    // Resources
    public List<Sprite> playerSprites;
    public List<Sprite> weaponSprites;
    public List<int> weaponPrizes;
    public List<int> xpTable;

    // References
    public Player player;
    // public Weapon weapon;

    // Logic
    public int money;
    public int experience;

    // Save state
    /*
     * INT prefferedSkin
     * INT moneyAmount
     * INT experience
     * INT weaponLevel
     */
    public void SaveState()
    {
        Debug.Log("SaveState() initiated");
    }
    public void LoadState(Scene s, LoadSceneMode mode)
    {
        Debug.Log("LoadState() initiated");
        SceneManager.sceneLoaded -= LoadState;

        if (!PlayerPrefs.HasKey("SaveState"))
        {
            Debug.Log("No savegame detected, continuing...");
            return;
        }

        string[] data = PlayerPrefs.GetString("SaveState").Split('|');

        // Load prefferedSkin

        // Load moneyAmount
        money = int.Parse(data[1]);

        // Load experience
        experience = int.Parse(data[2]);

        // Load weaponLevel
    }
}
