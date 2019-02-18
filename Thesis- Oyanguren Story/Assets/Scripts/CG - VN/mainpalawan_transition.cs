using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainpalawan_transition : MonoBehaviour {

    private bool playerEnter;
    public cgManager cgman;
    private bool istriggered;
    public string[] lines;
    
    public string[] img;
    public Sprite[] images;
    private LoadNewArea lna;
    private musicController mc;

    // Use this for initialization
    void Start () {
        lna = new LoadNewArea();
	}
	
	// Update is called once per frame
	void Update () {

        if (mc == null)
        {
            mc = FindObjectOfType<musicController>();
        }

        if (Input.GetKeyDown(KeyCode.E) && playerEnter)
        {
            mc.switchTrack(3);
            mc.musicCanPlay = true;
			cgman.textLines = lines;
            cgman.textimage = img;
            
            cgman.images = images;
            

            if (!cgman.cgActive)
            {
                cgman.currentLine = 0;
                cgman.showDialogue();
                istriggered = true;
                
            }
        }

            
            if (cgman.currentLine == 13 && istriggered)
        	{
        	
            lna.loadFromDialogue("palawan");
            istriggered = false;
            playerEnter =false;                  
            
       	 	}
     
   		
   	}


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerEnter = true;
           


        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerEnter = false;

        }
    }



}

