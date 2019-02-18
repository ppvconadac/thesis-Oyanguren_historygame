using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class experienceManager : MonoBehaviour {

    private DamageManager dm;
    private PlayerHealthManager phm;
    public int currentLevel;
    public int currentExperience;
    public int maxExperience;
    private sfxManager sfxman;
    private static bool exists;
   


	// Use this for initialization
	void Start () {
        currentLevel = 1;
        currentExperience = 0;
        maxExperience = currentLevel * 100;
        sfxman = FindObjectOfType<sfxManager>();
        dm = FindObjectOfType<DamageManager>();
        phm = FindObjectOfType<PlayerHealthManager>();
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
		if(currentExperience >= maxExperience)
        {
            sfxman.levelUP.Play();
            dm.levelUp();
            phm.playerMaxHealth += 10;
            phm.playerCurrentHealth = phm.playerMaxHealth;
            currentLevel += 1;
            currentExperience = currentExperience - maxExperience;
            maxExperience = currentLevel * 100;
        }
	}
}
