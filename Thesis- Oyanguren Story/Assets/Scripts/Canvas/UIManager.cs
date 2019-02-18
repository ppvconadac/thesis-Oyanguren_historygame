using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

    
    public Text hpText;
    private PlayerHealthManager playerHealth;
    public Slider healthBar;
    private experienceManager experience;
    public Slider experienceBar;
    public Text experienceText;
    GameObject[] pauseObjects;
    private LoadNewArea lna;
    GameObject[] gameOver;
    public GameObject player;
    public GameObject tip;
    public GameObject quest;
    

    // Use this for initialization
    void Start () {
        Time.timeScale = 1;
        pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");
        gameOver = GameObject.FindGameObjectsWithTag("gameOver");
        hidePaused();
        hideGameOver();
        lna = new LoadNewArea();

    }
	
	// Update is called once per frame
	void Update () {

        if (player == null)
        {
           
            player = GameObject.FindWithTag("Player");
        }
        if (playerHealth == null && experience == null)
        {
            if (FindObjectOfType<PlayerHealthManager>() != null)
            {
                playerHealth = FindObjectOfType<PlayerHealthManager>();
            }
            if (FindObjectOfType<experienceManager>() != null)
            {
                experience = FindObjectOfType<experienceManager>();
            }
            
            
        }
       
        if(playerHealth != null)
        {
            healthBar.maxValue = playerHealth.playerMaxHealth;
            healthBar.value = playerHealth.playerCurrentHealth;
            hpText.text = playerHealth.playerCurrentHealth + " / " + playerHealth.playerMaxHealth;
        }
       
        if(experience != null)
        {
            experienceBar.maxValue = experience.maxExperience;
            experienceBar.value = experience.currentExperience;
            experienceText.text = "Lv." + experience.currentLevel + " (" + experience.currentExperience + "/" + experience.maxExperience + ")";
        }
        

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                showPaused();
            }
            else if (Time.timeScale == 0)
            {
                Debug.Log("high");
                Time.timeScale = 1;
                hidePaused();
            }
        }

    }


    //controls the pausing of the scene
    public void pauseControl()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            showPaused();
        }
        else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            hidePaused();
        }
    }

    //shows objects with ShowOnPause tag
    public void showPaused()
    {
        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(true);
        }
    }

    public void showGameOver()
    {
        foreach (GameObject g in gameOver)
        {
            g.SetActive(true);
        }
    }
    public void hideGameOver()
    {
        foreach (GameObject g in gameOver)
        {
            g.SetActive(false);
        }
    }

    //hides objects with ShowOnPause tag
    public void hidePaused()
    {
        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(false);
        }
    }
    public void exitGame()
    {
        Application.Quit();
    }
    public void reload()
    {
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
        playerHealth.playerCurrentHealth = playerHealth.playerMaxHealth;
        player.SetActive(true);
        playerHealth.isactive = true;

    }
    public void closetip()
    {
        tip.SetActive(false);

    }
    public void closequest() {
        quest.SetActive(false);
    }

    //loads inputted level

}
