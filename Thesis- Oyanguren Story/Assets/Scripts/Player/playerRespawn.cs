using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class playerRespawn : MonoBehaviour {
    public float respawntime;
    public float currentrestime;
    public bool respawnon;
    public PlayerHealthManager phm;
    public GameObject player;
    private Vector3 targetPos;
    public float moveSpeed;
    private UIManager uiman;
    public GameObject respawn;
    
    // Use this for initialization
    void Start () {
        respawnon = true;
        currentrestime = respawntime;
        

    }
	
	// Update is called once per frame
	void Update () {
       
        
        if (phm == null && player == null) { 
        phm = FindObjectOfType<PlayerHealthManager>();
        player = GameObject.FindWithTag("Player");
        }

        if(uiman == null)
        {
            uiman = FindObjectOfType<UIManager>();
        }

        if(respawn == null)
        {
            respawn = GameObject.Find("Respawn");
            respawn.SetActive(false);
        }
        targetPos = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPos, moveSpeed * Time.deltaTime);

        if (!phm.isactive)
        {

            
            if (respawnon)
            {
                if (currentrestime > 0)
                {
                    respawn.SetActive(true);

                    currentrestime -= Time.deltaTime;
                }

                if (currentrestime <= 0)
                { 
                    respawn.SetActive(false);
                    phm.playerCurrentHealth = phm.playerMaxHealth / 3;
                    player.SetActive(true);
                    phm.isactive = true;
                    

                    currentrestime = respawntime;
                }
            }
            else if (!respawnon)
            {
                uiman.showGameOver();
            }
        }
    }
    public void restartCurrentScene()
    {
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
        phm.playerCurrentHealth = phm.playerMaxHealth;
        player.SetActive(true);
        phm.isactive = true;

    }
   
}
