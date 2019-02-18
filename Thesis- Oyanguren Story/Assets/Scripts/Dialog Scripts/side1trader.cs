using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class side1trader : MonoBehaviour {

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
    private bool dialogOngoing;
    public QuestManager qm;
    public side1Palawan s1p;
    public GameObject btn1;
    public GameObject btn2;
    public Text btntext;
    public Text btntext2;
    public string btext;
    public string btext2;
    public GameObject tips;
    public Text tip;
    [TextArea]
    public string tiptext;
    public mangoController mcont;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.E) && playerEnter)
        {
            if (s1p.questActive == true)
            {
               if(s1p.questIndex == 1)
                {
                    dMan.textLines = lines2;
                    dMan.textimage = img2;
                    dMan.textName = charac2;
                    dMan.images = images;
                    Debug.Log(dMan.currentLine);

                    if (!dMan.dialogActive)
                    {
                        dMan.currentLine = 0;
                        dMan.showDialogue();
                        istriggered = true;
                        s1p.questCompleted();

                    }
                   
                }
                else
                {
                    dMan.textLines = lines3;
                    dMan.textimage = img3;
                    dMan.textName = charac3;
                    dMan.images = images;
                    Debug.Log(dMan.currentLine);

                    if (!dMan.dialogActive)
                    {
                        dMan.currentLine = 0;
                        dMan.showDialogue();

                    }
                }

            }
            else
            {
                dMan.textLines = lines;
                dMan.textimage = img;
                dMan.textName = charac;
                dMan.images = images;
                Debug.Log(dMan.currentLine);
               
                if (!dMan.dialogActive)
                {
                    dMan.currentLine = 0;
                    dMan.showDialogue();

                }

            }
            
        }
        if (dMan.currentLine == 8 && playerEnter)
        {

            dMan.buttonActive = true;
            btntext.text = btext;
            btntext2.text = btext2;
            btn1.SetActive(true);
            btn2.SetActive(true);
        }
    }

   

    public void choosebtn()
    {

        qm.side1active = true;
        s1p.questActive = true;
        qm.questActivated();
        qm.side1btn.gameObject.SetActive(true);
        dMan.buttonActive = false;
        btn1.SetActive(false);
        btn2.SetActive(false);
        dMan.currentLine++;
        tip.text = tiptext;
        tips.SetActive(true);
        mcont.setMangoActive();

    }
    public void choosebtn2()
    {

        
        dMan.buttonActive = false;
        btn1.SetActive(false);
        btn2.SetActive(false);
        dMan.currentLine ++;

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
