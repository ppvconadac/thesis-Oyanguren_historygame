using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour {


    public int playerMaxHealth;
    public int playerCurrentHealth;
    public bool isactive;
    public GameObject[] attackCollider;

    // Use this for initialization
    void Start () {
    	isactive = true;
        playerCurrentHealth = playerMaxHealth;
        
	}
	
	// Update is called once per frame
	void Update () {

     
        if (playerCurrentHealth <= 0)
        {
            disableColliders();
            isactive = false;
            gameObject.SetActive(false);

        }
        if(playerCurrentHealth > playerMaxHealth)
        {
            playerCurrentHealth = playerMaxHealth;
        }
	}

    public void HurtPlayer(int damage)
    {
        playerCurrentHealth -= damage;
        Debug.Log(playerCurrentHealth);
    }

    public void SetMaxHealth()
    {
        playerCurrentHealth = playerMaxHealth;
    }

    public void disableColliders()
    {
        Debug.Log("ACCOLL");
        foreach (GameObject g in attackCollider)
        {
            g.SetActive(false);
        }
    }
}
