//================================
// Alex
//  Does nothing right now
//================================
using UnityEngine;
using System.Collections;

public class AI_Manager : MonoBehaviour {

    public static AI_Manager instance = null;

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
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
