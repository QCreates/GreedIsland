using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{ 
    public static GameManager instance;
    private void Awake()
    {
        if(GameManager.instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        
        SceneManager.sceneLoaded += LoadState;
        DontDestroyOnLoad(gameObject);

    }


    //Ressources
    public List<Sprite> playerSprites;
    public List<Sprite> weaponSprites;
    public List<int> weaponPrices;
    public List<int> xpTable;

    // References
    public Player player;
    //public weapon weapon...
    public FloatingTextManager floatingTextManager;

    //Logic
    public int booty;
    public int experience;

    // Floating text
    public void ShowText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        floatingTextManager.Show(msg, fontSize, color, position, motion, duration);
        
    }

    // Save state
    /*
     * INT prefered Skin
     * INT booty
     * INT experience
     * INT weaponLevel
     */
     public void SaveState()
     {
        string s = "";

        s += "0" + "|";
        s += booty.ToString() + "|";
        s += experience.ToString() + "|";
        s += "0";


        PlayerPrefs.SetString("SaveState", s);
        
     }
     public void LoadState(Scene s, LoadSceneMode mode)
     {
         if (!PlayerPrefs.HasKey("SaveState"))
             return;


         string[] data = PlayerPrefs.GetString("SaveState").Split('|');

            // Change Player skin
            booty = int.Parse(data[1]);
            experience = int.Parse(data[2]);
            // Change the weapon Level

        
        Debug.Log("LoadState");
     }
}
//3hr 3min 40 s