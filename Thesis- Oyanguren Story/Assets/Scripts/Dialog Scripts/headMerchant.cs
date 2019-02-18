using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class headMerchant : MonoBehaviour {
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

    private bool playerEnter;
   
    public side2Palawan s2p;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.E) && playerEnter)
        {
            if(s2p.questActive== true)
            {
                if (s2p.questIndex == 0)
                {
                    questInstance1();
                }
                else if (s2p.questIndex == 5)
                {
                    questInstance2();
                }
            }
            else
            {
                genericDialogue();
            }

        }
        if (!dMan.dialogActive && istriggered)
        {
            s2p.questCompleted();
            istriggered = false;
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
            
        }

    }

    private void genericDialogue()
    {
        dMan.textLines = lines3;
        dMan.textimage = img3;
        dMan.textName = charac3;
        dMan.images = images;

        if (!dMan.dialogActive)
        {
            dMan.currentLine = 0;
            dMan.showDialogue();


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
            Debug.Log("Bye");
        }
    }
}
