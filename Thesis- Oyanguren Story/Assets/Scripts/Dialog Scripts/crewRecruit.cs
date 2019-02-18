using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crewRecruit : MonoBehaviour {

	// Use this for initialization
	 public DialogueManager dMan;
    public string[] lines;
    public string[] charac;
    public string[] img;
    public string[] lines2;
    public string[] charac2;
    public string[] img2;
    public Sprite[] images;
    private bool istriggered;
    private bool playerEnter;
    public questMainl2 qmp;
    private bool isRecruited;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.E) && playerEnter)
        {
            if (!isRecruited)
            {
                questInstance1();
            }
            else{
            	genericDialogue();

            }


        }
        if (!dMan.dialogActive && istriggered)
        {
            qmp.recruitCount += 1;
            isRecruited = true;
            istriggered = false;
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

    private void questInstance1()
    {
        dMan.textLines = lines;
        dMan.textimage = img;
        dMan.textName = charac;
        dMan.images = images;

        if (!dMan.dialogActive)
        {

            dMan.showDialogue();
            dMan.currentLine = 0;
            istriggered = true;

        }
    }

     private void genericDialogue()
    {
        dMan.textLines = lines2;
        dMan.textimage = img2;
        dMan.textName = charac2;
        dMan.images = images;

        if (!dMan.dialogActive)
        {

            dMan.showDialogue();
            dMan.currentLine = 0;
            

        }
    }
}
