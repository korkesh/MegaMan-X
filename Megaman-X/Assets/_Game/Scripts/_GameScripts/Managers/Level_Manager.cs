//================================
// Alex
//  Level Manager, deals with checkpoints and fragemnts
//================================
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Level_Manager : Singleton<Level_Manager>
{

    //public static Level_Manager instance = null;

    //================================
    // Variables
    //================================

    public enum Levels
    {
        HUB = 0,
        TUTORIAL = 1,
        CANNON = 2,
        DAMAGE = 3,
        BOSS = 4,
        MENU = 5
    }

    public string SceneName;
    public Levels CurrentLevel;
    public Levels FurthestLevelProgressed;
    public List<string> levels;
    public Vector3 CheckPointPos;
    public Vector3 Rot;

    //-----------------
    // Defaults 
    //-----------------

    public Levels defaultLevel;
    public string defaultGameScene;
    public Vector3 defaultCheckPoint;
    public bool checkPointContinue;

    //-----------------
    // Collectibles 
    //-----------------

    public int totalNumMemoryFrag;
    public int totalNumCollectibles;
    public int totalTutorialTickets;
    public int totalCannonTickets;
    public int totalDamageTickets;

    public int collectedMemoryFrag;
    public int collectedCollectibles;
    public int collectedTutorialTickets;
    public int collectedCannonTickets;
    public int collectedDamageTickets;

    //================================
    // Methods
    //================================

    //-----------------
    // Initialization
    //-----------------

    void Awake()
    {
        //Check if instance already exists
        if (instance == null)
        {
            //if not, set instance to this
            instance = this;
        }
        //If instance already exists and it's not this:
        else if (instance != this)
        {
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);
        }

        //Sets this to not be destroyed when reloading scene
        // DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    void Start()
    {
        ContinueLevel();

    }

    // Update is called once per frame
    void Update()
    {
    }

    /// <summary>
    /// Creates a new game save in player prefs
    /// </summary>
    public void NewGamePlayerPrefs()
    {

        PlayerPrefs.SetString("CurrentLevel", "Tutorial");
        PlayerPrefs.SetFloat("Save", 0);
        PlayerPrefs.SetInt("TotalNumMemoryFrag", totalNumMemoryFrag);
        PlayerPrefs.SetInt("TotalNumCollectibles", totalNumCollectibles);
        PlayerPrefs.SetInt("totalTutorialTickets", totalTutorialTickets);
        PlayerPrefs.SetInt("totalCannonTickets", totalCannonTickets);
        PlayerPrefs.SetInt("totalDamageTickets", totalDamageTickets);
        PlayerPrefs.SetInt("LevelComplete", 0);
        PlayerPrefs.SetInt("FurthestLevelProgressed", 0);
        PlayerPrefs.SetFloat("CheckPointX", defaultCheckPoint.x);
        PlayerPrefs.SetFloat("CheckPointY", defaultCheckPoint.y);
        PlayerPrefs.SetFloat("CheckPointZ", defaultCheckPoint.z);
        PlayerPrefs.SetFloat("RotationY", 0);
        PlayerPrefs.SetInt("collectedMemoryFrag", 0);
        PlayerPrefs.SetInt("collectedCollectibles", 0);
        PlayerPrefs.SetInt("collectedTutorialTickets", 0);
        PlayerPrefs.SetInt("collectedCannonTickets", 0);
        PlayerPrefs.SetInt("collectedDamageTickets", 0);
        Rot = Vector3.zero;
        CheckPointPos = defaultCheckPoint;
    }

    //TODO: when checkpoints are added change this
    //public void Death()
    //{
    //    UI_Manager.instance.GameOver();
    //    //Game_Manager.instance.ChangeScene(defaultGameScene);
    //}

    public void SaveGame()
    {
        PlayerPrefs.SetFloat("Save", 1);
    }

    public bool LevelComplete()
    {
        if (PlayerPrefs.GetInt("TotalNumMemoryFrag") == Character_Manager.instance.totalMemoryFragmentsCollected)
        {
            if (PlayerPrefs.GetInt("LevelComplete") == 0)
            {
                PlayerPrefs.SetInt("LevelComplete", 1);
                return true;
            }
        }
        return false;
    }

    // Override of prev; this function keeps track of the most recent level completed by the player
    public void LevelComplete(Levels lvl)
    {
        PlayerPrefs.SetInt("FurthestLevelProgressed", (int)lvl);
    }

    public void newCheckPoint(Vector3 pos, Vector3 Rotation, string Level)
    {
        CheckPointPos = pos;
        Rot = Rotation;
        PlayerPrefs.SetFloat("CheckPointX", CheckPointPos.x);
        PlayerPrefs.SetFloat("CheckPointY", CheckPointPos.y);
        PlayerPrefs.SetFloat("CheckPointZ", CheckPointPos.z);
        PlayerPrefs.SetFloat("RotationY", Rotation.y);
        PlayerPrefs.SetString("CurrentLevel", Level);
    }

    public void ContinueLevel()
    {
        // Game_Manager.instance.changeGameState(Game_Manager.GameState.PLAY);

        CheckPointPos.x = PlayerPrefs.GetFloat("CheckPointX");
        CheckPointPos.y = PlayerPrefs.GetFloat("CheckPointY");
        CheckPointPos.z = PlayerPrefs.GetFloat("CheckPointZ");
        Rot.x = 0;
        Rot.y = PlayerPrefs.GetFloat("RotationY");
        Rot.z = 0;
        SceneName = PlayerPrefs.GetString("CurrentLevel");

        if (CheckPointPos == Vector3.zero)
        {
            PlayerPrefs.SetFloat("CheckPointX", defaultCheckPoint.x);
            PlayerPrefs.SetFloat("CheckPointY", defaultCheckPoint.y);
            PlayerPrefs.SetFloat("CheckPointZ", defaultCheckPoint.z);
            CheckPointPos = defaultCheckPoint;
        }
    }


    public void updateLevelTickets(Items i)
    {
        int t;
        t = PlayerPrefs.GetInt("TotalNumCollectibles");
        t++;
        PlayerPrefs.SetInt("TotalNumCollectibles", t);
        switch (CurrentLevel)
        {
            
            case Levels.TUTORIAL:
                t = PlayerPrefs.GetInt("collectedTutorialTickets");
                t++;
                PlayerPrefs.SetInt("collectedTutorialTickets", t);
                break;
            case Levels.CANNON:
                t = PlayerPrefs.GetInt("collectedCannonTickets");
                t++;
                PlayerPrefs.SetInt("collectedCannonTickets", t);
                break;
            case Levels.DAMAGE:
                t = PlayerPrefs.GetInt("collectedDamageTickets");
                t++;
                PlayerPrefs.SetInt("collectedDamageTickets", t);
                break;
            
        }
    }
}
