using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class councilDialogue : MonoBehaviour {
     public DialogueManager dMan;
    public string[] lines;
    public string[] charac;
    public string[] img;
    public Sprite[] images;
    private bool istriggered;
    private bool istriggered2;
    private bool cgistriggered;
    private bool playerEnter;
    public questMainl3 qmp;

    public string[] lines2;
    public string[] charac2;
    public string[] img2;

    public cgManager cgman;

    public string[] cglines;

    public string[] cgimg;
    public Sprite[] cgimages;
    private musicController mc;
    private UIManager pr;
    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (mc == null)
        {
            mc = FindObjectOfType<musicController>();
        }
        if (pr == null)
        {
            pr = FindObjectOfType<UIManager>();
        }
        if (Input.GetKeyDown(KeyCode.E) && playerEnter)
        {
          if(qmp.questIndex == 0)
            {
                questInstance1();
            }
            if (qmp.questIndex ==2)
            {
                questInstance2();
            }

        }



        if (!dMan.dialogActive && istriggered)
        {
            istriggered = false;
            qmp.questCompleted();
        }

        if (!dMan.dialogActive && istriggered2)
        {
            Debug.Log("INnnnn");
            istriggered2 = false;
            runCG();
        }

        if(cgistriggered == true && !cgman.cgActive)
        {
            Debug.Log("iinnn");
            pr.showGameOver();
            cgistriggered = false;
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

    private void questInstance2()
    {

        dMan.textLines = lines2;
        dMan.textimage = img2;
        dMan.textName = charac2;
        dMan.images = images;

        if (!dMan.dialogActive)
        {

            
            dMan.showDialogue();
            dMan.currentLine = 0;
            istriggered2 = true;
            qmp.questCompleted();

        }
    }

    public void runCG()
    {
        mc.switchTrack(1);
        cgman.textLines = cglines;
        cgman.textimage = cgimg;
        cgman.images = cgimages;


        if (!cgman.cgActive)
        {
            cgman.currentLine = 0;
            cgman.showDialogue();
            cgistriggered = true;

        }



    }





}

