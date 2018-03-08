//================================
// Alex
//  for sound
//================================
using UnityEngine;
using System.Collections;

public class Audio_Manager : Singleton<Audio_Manager>
{

    //public static Audio_Manager instance = null;

    public AudioSource DreamBGM;
    public AudioSource NightmareBGM;

    public float volume = 1.0f;
    public float bgm = 1.0f;

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

    public void setVolume(float v)
    {
        volume = v;
        gameObject.GetComponent<AudioSource>().Play();
        AudioListener.volume = v;
    }

    public void setBGM(float v)
    {
        bgm = v;
    }
}
