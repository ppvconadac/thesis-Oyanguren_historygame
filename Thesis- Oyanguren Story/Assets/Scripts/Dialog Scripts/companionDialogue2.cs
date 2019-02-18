using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class companionDialogue2 : MonoBehaviour {

	// Use this for initialization
	 // Use this for initialization
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
    public string[] lines3;
    public string[] charac3;
    public string[] img3;
     public string[] lines4;
    public string[] charac4;
    public string[] img4;
    
    public cgManager cgman;
   
    
    public string[] cglines2;

    public string[] cgimg2;
    public Sprite[] cgimages2;
  
    private bool load;
    private bool load2;
    public Transform pwarptarget;
    private PlayerMovement2 thePlayer;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (thePlayer == null)
        {
            thePlayer = FindObjectOfType<PlayerMovement2>();
        }
        if (Input.GetKeyDown(KeyCode.E) && playerEnter)
        {
            if (qmp.questIndex ==1)
            {
                questInstance1();
               
            }

            else if(qmp.questIndex == 4){
                questInstance2();

            }
            else{
            	genericDialog();
            }


        }

       


        if (!dMan.dialogActive && istriggered && !load)
        {
            
            istriggered = false;
        }


        if (!dMan.dialogActive && istriggered && load && !load2)
        {
            dMan.background.gameObject.SetActive(true);
            runVN();
            
            
            
        }

        if (!dMan.dialogActive && istriggered && load && load2)
        {
             Debug.Log("towarp");
            StartCoroutine("warptotarget");

  
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
            qmp.questCompleted();
            dMan.showDialogue();
            dMan.currentLine = 0;
            istriggered = true;
            load = true;
            
            

        }
    }

    private void genericDialog()
    {
        
        dMan.textLines = lines3;
        dMan.textimage = img3;
        dMan.textName = charac3;
        dMan.images = images;

        if (!dMan.dialogActive)
        {

            dMan.showDialogue();
            dMan.currentLine = 0;
          
        }
    }

   
    public void runVN()
    {
        
        dMan.textLines = lines4;
        dMan.textimage = img4;
        dMan.textName = charac4;
        dMan.images = images;


        if (!dMan.dialogActive)
        {
            dMan.currentLine = 0;
            dMan.showDialogue();
            istriggered  = true;
            load = true;
            load2 = true;

        }


     
    }

        public void runCG2()
        {
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

         IEnumerator warptotarget()
    {
        Debug.Log("WARPING");
        istriggered = false;
        load = false;
            load2 = false;
        
        ScreenFader sf = GameObject.FindGameObjectWithTag("Fader").GetComponent<ScreenFader>();
        
      
      yield return StartCoroutine(sf.FadeToBlack());

        dMan.background.gameObject.SetActive(false);
        thePlayer.gameObject.transform.position = pwarptarget.position;
       
         thePlayer.anim.SetFloat("LastMoveX", 0f);
         thePlayer.anim.SetFloat("LastMoveY", 1f);
        
        yield return StartCoroutine(sf.FadeToClear());
        istriggered = false;

            load = false;
            load2 = false;
        qmp.questCompleted();
            

    }
}
