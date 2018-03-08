//================================
// Alex
//  not needed anymore
//================================
using UnityEngine;
using System.Collections;

public class DontDestroyOnLoad : MonoBehaviour {

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

}
