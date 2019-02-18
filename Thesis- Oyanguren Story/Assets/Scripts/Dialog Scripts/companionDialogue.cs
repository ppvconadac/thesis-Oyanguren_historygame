using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class companionDialogue : MonoBehaviour
{

    // Use this for initialization
    public DialogueManager dMan;
    public string[] lines;
    public string[] charac;
    public string[] img;
    public Sprite[] images;
    private bool istriggered;
   private bool cgistriggered;
    private bool playerEnter;
    public questMainPalawan qmp;
    public GameObject btn1;
    public GameObject btn2;
    public GameObject btn3;
    public Text btntext;
    public Text btntext2;
    public Text btntext3;
    public string btext;
    public string btext2;
    public string btext3;
    public bool badending;

    public string[] lines2;
    public string[] charac2;
    public string[] img2;
    public Sprite[] images2;
    public cgManager cgman;
   
    public string[] cglines;

    public string[] cgimg;
    public Sprite[] cgimages;
    public string[] cglines2;

    public string[] cgimg2;
    public Sprite[] cgimages2;
    private LoadNewArea lna;
    private bool load;
    private UIManager pr;
    private musicController mc;

    // Use this for initialization
    void Start()
    {
        lna = new LoadNewArea();
    }

    // Update is called once per frame
    void Update()
    {
        if(mc == null)
        {
            mc = FindObjectOfType<musicController>();
        }
        if(pr == null)
        {
            pr = FindObjectOfType<UIManager>();
        }
        if (Input.GetKeyDown(KeyCode.E) && playerEnter)
        {
            if (qmp.questIndex >8)
            {
                questInstance1();
                if(qmp.questIndex == 9)
                {
                    qmp.questCompleted();
                }
                
            }


        }

        if (dMan.currentLine == 7 && playerEnter)
        {

            dMan.buttonActive = true;
            btntext.text = btext;
            btntext2.text = btext2;
            btntext3.text = btext3;
            btn1.SetActive(true);
            btn2.SetActive(true);
            btn3.SetActive(true);
        }

        if (!dMan.dialogActive && istriggered && !load)
        {
            
            istriggered = false;
        }

 

        if (cgman.currentLine == 17 && cgistriggered == true)
        {
            
            dMan.background.gameObject.SetActive(true);
            cgistriggered = false;
            playerEnter = false;
            questInstance2();

        }

        if (!dMan.dialogActive && istriggered && load)
        {
            
            lna.loadFromDialogue("Level2");
            
            istriggered = false;
            //dMan.background.gameObject.SetActive(false);

        }
        if(cgistriggered && badending && !cgman.cgActive)
        {
            Debug.Log("ello");
            pr.showGameOver();
            cgistriggered = false;
            badending = false;
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
        dMan.images = images2;

        if (!dMan.dialogActive)
        {

            dMan.showDialogue();
            dMan.currentLine = 0;
            istriggered = true;
            load = true;

        }
    }

    public void choosebtn()
    {

        Debug.Log("button1selected");
        dMan.buttonActive = false;
        btn1.SetActive(false);
        btn2.SetActive(false);
        btn3.SetActive(false);
        dMan.currentLine++;
        runCG();


    }
    public void choosebtn2()
    {


        dMan.buttonActive = false;
        btn1.SetActive(false);
        btn2.SetActive(false);
        btn3.SetActive(false);
        dMan.currentLine++;

    }


    public void choosebtn3()
    {


        dMan.buttonActive = false;
        btn1.SetActive(false);
        btn2.SetActive(false);
        btn3.SetActive(false);
        dMan.currentLine++;
        runCG2();
    }

    public void runCG()
    {
        Debug.Log("CGGGG");
        cgman.textLines = cglines;
        cgman.textimage = cgimg;
        cgman.images = cgimages;


        if (!cgman.cgActive)
        {
            cgman.currentLine = 0;
            cgman.showDialogue();
            cgistriggered = true;
            badending = true;
        }


     
    }

        public void runCG2()
        {
        mc.switchTrack(3);
            Debug.Log("CGGGG");
            cgman.textLines = cglines2;
            cgman.textimage = cgimg2;
            cgman.images = cgimages2;


            if (!cgman.cgActive)
            {
                cgman.currentLine = 0;
                cgman.showDialogue();
                cgistriggered = true;

            }


            

        }

    }


