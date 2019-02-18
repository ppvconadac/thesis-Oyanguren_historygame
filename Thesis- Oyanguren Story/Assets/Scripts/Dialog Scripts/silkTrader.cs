using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class silkTrader : MonoBehaviour {


    public DialogueManager dMan;
    public string[] lines;
    public string[] charac;
    public string[] img;
    public Sprite[] images;
    private bool istriggered;
    public string[] lines2;
    public string[] charac2;
    public string[] img2;
    public string[] lines3;
    public string[] charac3;
    public string[] img3;
    public string[] lines4;
    public string[] charac4;
    public string[] img4;
    public string[] lines5;
    public string[] charac5;
    public string[] img5;
    private bool playerEnter;
    private bool dialogOngoing;
    public bananaController bcont;
    
    public questMainPalawan qmp;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.E) && playerEnter)
        {
            if(qmp.questIndex == 0)
            {
                questInstance1();         
            }
            else if(qmp.questIndex == 1)
            {
                questInstance2();
            }
            else if(qmp.questIndex == 3)
            {
                questInstance3();
            }
            else if(qmp.questIndex == 8)
            {
                questInstance4();
            }
            else
            {
                genericDialogue();
            }
          
        }
        if (!dMan.dialogActive && istriggered)
        {
            qmp.questCompleted();
            istriggered = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerEnter = true;
            Debug.Log("Hello");


        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerEnter = false;

        }
    }

    private void questInstance1()
    {
        dMan.textLines = lines;
        dMan.textimage = img;
        dMan.textName = charac;
        dMan.images = images;

        if (!dMan.dialogActive)
        {

            dMan.currentLine = 0;
            dMan.showDialogue();
            istriggered = true;

        }
    }

    private void questInstance2()
    {
        dMan.textLines = lines2;
        dMan.textimage = img2;
        dMan.textName = charac2;
        dMan.images = images;

        if (!dMan.dialogActive)
        {
            dMan.currentLine = 0;
            dMan.showDialogue();
            
            istriggered = true;
            bcont.setBananaActive();
        }

    }
    private void questInstance3()
    {
        dMan.textLines = lines3;
        dMan.textimage = img3;
        dMan.textName = charac3;
        dMan.images = images;

        if (!dMan.dialogActive)
        {
            dMan.currentLine = 0;
            dMan.showDialogue();
           
            istriggered = true;
        
        }

    }

    private void questInstance4()
    {
        dMan.textLines = lines4;
        dMan.textimage = img4;
        dMan.textName = charac4;
        dMan.images = images;

        if (!dMan.dialogActive)
        {
            dMan.currentLine = 0;
            dMan.showDialogue();
            
            istriggered = true;

        }

    }
    private void genericDialogue()
    {
        dMan.textLines = lines5;
        dMan.textimage = img5;
        dMan.textName = charac5;
        dMan.images = images;

        if (!dMan.dialogActive)
        {
            dMan.currentLine = 0;
            dMan.showDialogue();
           

        }

    }
}
