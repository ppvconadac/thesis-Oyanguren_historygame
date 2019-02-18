using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class datuDaupan : MonoBehaviour
{

    public DialogueManager dMan;
    public string[] lines;
    public string[] charac;
    public string[] img;
    public Sprite[] images;
    private bool istriggered;
    private bool cgistriggered;
    private bool playerEnter;
    public questMainl2 qmp;
    public string[] lines2;
    public string[] charac2;
    public string[] img2;
    public Sprite[] images2;


    public cgManager cgman;


    public string[] cglines;

    public string[] cgimg;
    public Sprite[] cgimage;

    private bool load;
    private LoadNewArea lna;

    public GameObject btn1;
    public GameObject btn2;
    
    public Text btntext;
    public Text btntext2;
   
    public string btext;
    public string btext2;
    private musicController mc;
    private bool hasBeenActivated;


    private PlayerMovement2 thePlayer;
    // Use this for initialization
    void Start()
    {
        lna = new LoadNewArea();
    }

    // Update is called once per frame
    void Update()
    {
        if (mc == null)
        {
            mc = FindObjectOfType<musicController>();
        }
        if (thePlayer == null)
        {
            thePlayer = FindObjectOfType<PlayerMovement2>();
        }

        if (Input.GetKeyDown(KeyCode.E) && playerEnter)
        {
            questInstance1();

        }
        if (dMan.currentLine == 20 && playerEnter)
        {

            dMan.buttonActive = true;
            btntext.text = btext;
            btntext2.text = btext2;
           
            btn1.SetActive(true);
            btn2.SetActive(true);
            
        }

        if (cgman.currentLine == 3 && cgistriggered == true)
        {

            dMan.background.gameObject.SetActive(true);
            cgistriggered = false;
            playerEnter = false;
            questInstance2();

        }

        if (!dMan.dialogActive && istriggered && !load)
        {

            istriggered = false;
        }

        if (!dMan.dialogActive && istriggered && load)
        {

            lna.loadFromDialogue("Level3");

            istriggered = false;
            //dMan.background.gameObject.SetActive(false);


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
            if (!hasBeenActivated)
            {
                qmp.questCompleted();
            }
            dMan.showDialogue();
            dMan.currentLine = 0;
            istriggered = true;
            hasBeenActivated = true;

        }
    }

    private void questInstance2()
    {
        dMan.background.gameObject.SetActive(true);
        dMan.textLines = lines2;
        dMan.textimage = img2;
        dMan.textName = charac2;
        dMan.images = images2;

        if (!dMan.dialogActive)
        {

            dMan.showDialogue();
            dMan.currentLine = -1;
            istriggered = true;
            load = true;

        }
    }

    public void choosebtn()
    {

        qmp.questCompleted();
        dMan.buttonActive = false;
        btn1.SetActive(false);
        btn2.SetActive(false);
        
        dMan.currentLine++;
        runCG();


    }
    public void choosebtn2()
    {


        dMan.buttonActive = false;
        btn1.SetActive(false);
        btn2.SetActive(false);
       
        dMan.currentLine++;

    }

    public void runCG()
    {
       
        cgman.textLines = cglines;
        cgman.textimage = cgimg;
        cgman.images = cgimage;


        if (!cgman.cgActive)
        {
            mc.switchTrack(3);
            cgman.currentLine = 0;
            cgman.showDialogue();
            cgistriggered = true;

        }



    }
}
