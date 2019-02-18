using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialogueHolder : MonoBehaviour {
    
    private DialogueManager dMan;

    private bool playerEnter;
    public string[] lines;
    public string[] charac;
    public string[] img;
    public string[] Replines;
    public string[] Repcharac;
    public string[] Repimg;
    public string[] Replines2;
    public string[] Repcharac2;
    public string[] Repimg2;
    public bool isButton;
    public bool isReply;
    public GameObject btn1;
    public GameObject btn2;
    public Text btntext;
    public Text btntext2;
    public string btext;
    public string btext2;
    public Sprite[] images;
    public GameObject boxTrigger;
    public bool istriggered;



    // Use this for initialization
    void Start () {
        
        dMan = FindObjectOfType<DialogueManager>();
        

    }
	
	// Update is called once per frame
	void Update () {

        if (!dMan.isreply && !istriggered)
        {
            dMan.textLines = lines;
            dMan.textimage = img;
            dMan.textName = charac;
            dMan.images = images;

            if (dMan.currentLine == 7)
            {
                dMan.buttonActive = true;
                btntext.text = btext;
                btntext2.text = btext2;
                btn1.SetActive(true);
                btn2.SetActive(true);
            }

            
            if (Input.GetKeyDown(KeyCode.E) && playerEnter)
            {
               
                if (!dMan.dialogActive)
                {

                    dMan.showDialogue();
                    dMan.currentLine = 0;


                }
            }
        }
        else if (dMan.isreply) {
           
            dMan.textLines = Replines;
            dMan.textimage = Repimg;
            dMan.textName = Repcharac;

            isReply = false;

        }

        
        
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            playerEnter = true;
            
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            playerEnter = false;
        }
    }
    public void choosebtn() {

        Replines = Replines2;
        Repimg = Repimg2;
        Repcharac = Repcharac2;
        boxTrigger.SetActive(true);
        istriggered = true;
        dMan.buttonActive = false;
        dMan.isreply = true;
        dMan.currentLine = -1;
        dMan.SkipToNextText();
        btn1.SetActive(false);
        btn2.SetActive(false);




    }
    public void choosebtn2()
    {
        dMan.buttonActive = false;
        
        dMan.isreply = true;
        dMan.currentLine = -1;
        dMan.SkipToNextText();
        btn1.SetActive(false);
        btn2.SetActive(false);

    }
}
