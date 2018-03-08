//================================
// Alex,Matt
//  Game Manager, deals with currecnt state of game
//================================
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class Game_Manager : MonoBehaviour {

    public static Game_Manager instance = null;

    //================================
    // Variables
    //================================

    //-----------------
    // State Variables
    //-----------------

    // Game Flow states enums
    public enum GameState
    {
        INTRO,
        MENU,
        PLAY,
        PAUSE,
        GAMEOVER,
        LEVELCOMPLETE,
        CINEMATIC
    }

    // Current States
    public GameState currentGameState;

    // temp
    public bool enableSmartCam = false;

    //================================
    // Methods
    //================================

    //-----------------
    // Initialization
    //-----------------

    /// Initialize Game States
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
        //DontDestroyOnLoad(gameObject);

         //currentGameState = GameState.INTRO;
       // NewGame(); // DEBUGGGGGG
    }

    /// <summary>
    /// Deletes current playerprefs and gets level manager and 
    /// character manager to create new ones with default values
    /// </summary>
    public void NewGame()
    {
        PlayerPrefs.DeleteAll();
        Level_Manager.Instance.NewGamePlayerPrefs();
        Character_Manager.instance.NewGamePlayerPrefs();
    }

    //-----------------
    // Updates
    //-----------------

    /// Update is called once per frame
    void Update()
    {
        //currentGameState = GameState.PLAY;// DEBUGGGGGG

        if (GameObject.FindGameObjectWithTag("SmartCam"))
        {
            if (enableSmartCam)
            {
                GameObject.FindGameObjectWithTag("SmartCam").SetActive(true);
            }
            else
            {
                GameObject.FindGameObjectWithTag("SmartCam").SetActive(false);

            }
        }
    }

    //-----------------
    // State Handling
    //-----------------

    /// change game state
    public void changeGameState(GameState gs)
    {
        
        // Current State Exit
        switch (currentGameState)
        {
            case GameState.INTRO:
                {
                    break;
                }
            case GameState.MENU:
                {
                    break;
                }
            case GameState.PAUSE:
                {
                    break;
                }
            case GameState.PLAY:
                {
                    break;
                }
            case GameState.LEVELCOMPLETE:
                {
                    ManipulationManager.instance.currentWorldState = ManipulationManager.WORLD_STATE.DREAM;

                    break;
                }
            case GameState.GAMEOVER:
                {
                    ManipulationManager.instance.currentWorldState = ManipulationManager.WORLD_STATE.DREAM;
                    break;
                }
        }

        // New State Enter
        switch (gs)
        {
            case GameState.INTRO:
                {
                    ManipulationManager.instance.currentWorldState = ManipulationManager.WORLD_STATE.DREAM;

                    break;
                }
            case GameState.MENU:
                {
                    ManipulationManager.instance.currentWorldState = ManipulationManager.WORLD_STATE.DREAM;

                    break;
                }
            case GameState.PAUSE:
                {
                   // Debug.Log("Entering: Pause");

                    break;
                }
            case GameState.PLAY:
                {
                   // Debug.Log("Entering: Play");

                    //text box fix
                    if(currentGameState != GameState.PAUSE && currentGameState != GameState.CINEMATIC)
                    {
                        ManipulationManager.instance.currentWorldState = ManipulationManager.WORLD_STATE.DREAM;
                    }
                    Character_Manager.instance.invincible = false;

                    break;
                }
            case GameState.LEVELCOMPLETE:
                {
                   // Debug.Log("Entering: Level Complete");

                    break;
                }
            case GameState.GAMEOVER:
                {
                   // Debug.Log("Entering: Game Over");

                    break;
                }
        }

        // State change
        currentGameState = gs;
    }

    //change state to play
    public void PlayGame()
    {
        
        changeGameState(GameState.PLAY);
    }

    // check if paused
    public bool isPaused()
    {
        return currentGameState == GameState.PAUSE;
    }

    // check if playing
    public bool isPlaying()
    {
        return currentGameState == GameState.PLAY;
    }

    // check if in menus
    public bool inMenu()
    {
        return currentGameState == GameState.MENU || currentGameState == GameState.INTRO;
    }

    //-----------------
    // Scene change
    //-----------------

    public void ChangeScene(string scene)
    {
        SceneManager.LoadScene(scene);       
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
