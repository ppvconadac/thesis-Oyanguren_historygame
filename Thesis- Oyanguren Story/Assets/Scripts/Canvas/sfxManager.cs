using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sfxManager : MonoBehaviour {

    public AudioSource swordSwing;
    public AudioSource fireCrackle;
    public AudioSource fireExplosion;
    public AudioSource itemPick;
    public AudioSource potionPick;
    public AudioSource levelUP;
    private static bool exists;
    // Use this for initialization
    void Start () {
        if (!exists)
        {
            exists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
