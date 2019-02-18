using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class cutside3v2 : MonoBehaviour {

    // Use this for initialization
    private DialogueManager dMan;

    public string[] lines;
    public string[] charac;
    public string[] img;
    public Sprite[] images;
    private bool playerEnter;

    private bool dialogOngoing;
    public bool istriggered;
    private bool finished;

   
    public side3Palawan qmp;
    public QuestManager qm;
    public zoneController zCont;
    private PlayerMovement2 thePlayer;
    public GameObject spiderController;



    // Use this for initialization
    void Start()
    {

        dMan = FindObjectOfType<DialogueManager>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (thePlayer == null)
        {
            thePlayer = FindObjectOfType<PlayerMovement2>();
        }
        if (playerEnter)
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
                playerEnter = false;
            }

        }


        if (!dMan.dialogActive && istriggered)
        {
            spiderController.SetActive(true);
            zCont.battleOn(true);
            
            qmp.questCompleted(); 
            
            istriggered = false;
            transform.gameObject.SetActive(false);


        }
        


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {

            playerEnter = true;


        }
    }
}
