using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class menuManager : MonoBehaviour {
   
    private LoadNewArea lna;

    // Use this for initialization
    void Start () {
        lna = new LoadNewArea();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void choosebtn()
    {
        lna.loadFromDialogue("main");
    }
    public void choosebtn2()
    {
        Application.Quit();
    }
}
