using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNewArea : MonoBehaviour {

    public string LevelToLoad;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Player_2")
        {
            SceneManager.LoadScene(LevelToLoad);
            
        }
    }

    public void loadFromDialogue(string name)
    {    
            SceneManager.LoadScene(name);
       
    }


}
