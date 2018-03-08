using UnityEngine;
using System.Collections;

public class HubManager : MonoBehaviour {

    public GameObject mainCamera;
    public GameObject bossCamera;

    public GameObject TutorialDoor;
    public GameObject Level1Door;
    public GameObject Level2Door;
    public GameObject BossDoor;

    public GameObject fragment;
    public Animator fragmentOpen;

    // Use this for initialization
    void Start () {
        Level_Manager.Instance.FurthestLevelProgressed = (Level_Manager.Levels)PlayerPrefs.GetInt("FurthestLevelProgressed");

        HubDoorToOpen();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    //-----------------
    // Hub Logic
    //-----------------
    public void HubDoorToOpen()
    {
        Game_Manager.instance.changeGameState(Game_Manager.GameState.CINEMATIC);

        switch (Level_Manager.Instance.FurthestLevelProgressed)
        {
            case Level_Manager.Levels.TUTORIAL:
                {
                    // Open Level 1 Door && close Tutorial Door

                    //tutorialCamera.SetActive(true);
                    //mainCamera.SetActive(false);
                    TutorialDoor.GetComponent<LowerDoor>().CloseDoor();
                    Level1Door.GetComponent<LowerDoor>().OpenDoor();

                    StartCoroutine(Play(""));

                    break;
                }
            case Level_Manager.Levels.CANNON:
                {
                    // Open Level 2 Door && close Level 1 Door

                    //level1Camera.SetActive(true);
                    //mainCamera.SetActive(false);
                    Level1Door.GetComponent<LowerDoor>().CloseDoor();
                    Level2Door.GetComponent<LowerDoor>().OpenDoor();

                    StartCoroutine(Play(""));

                    break;
                }
            case Level_Manager.Levels.DAMAGE:
                {
                    // Allow Boss Door Activation && close Level 2 Door

                    //level2Camera.SetActive(true);
                    bossCamera.SetActive(true);
                    fragment.SetActive(true);
                    Level2Door.GetComponent<LowerDoor>().CloseDoor();
                    fragmentOpen.SetTrigger("open");
                    //BossDoor.GetComponent<LowerDoor>().OpenDoor();

                    StartCoroutine(BossOpen("Boss"));

                    break;
                }
        }
    }

    public IEnumerator Play(string door)
    {
        yield return new WaitForSeconds(1.0f);

        bossCamera.SetActive(false);
        Game_Manager.instance.changeGameState(Game_Manager.GameState.PLAY);
    }

    public IEnumerator BossOpen(string door)
    {
        ManipulationManager.instance.currentWorldState = ManipulationManager.WORLD_STATE.NIGHTMARE;

        yield return new WaitForSeconds(5.0f);

        BossDoor.GetComponent<LowerDoor>().OpenDoor();

        yield return new WaitForSeconds(10.0f);

        bossCamera.SetActive(false);
        Game_Manager.instance.changeGameState(Game_Manager.GameState.PLAY);
    }
}
