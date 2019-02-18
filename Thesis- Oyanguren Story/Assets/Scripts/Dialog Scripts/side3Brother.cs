using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class side3Brother : MonoBehaviour {

    // Use this for initialization
    public DialogueManager dMan;
    public string[] lines;
    public string[] charac;
    public string[] img;
    public Sprite[] images;
    private bool istriggered;
    private bool playerEnter;
    public side3Palawan qmp;
    public zoneController zct;
    public GameObject exitTrigger;
    private musicController mc;
    

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (mc == null)
        {
            mc = FindObjectOfType<musicController>();
        }
        if (Input.GetKeyDown(KeyCode.E) && playerEnter)
        {
            if (qmp.questIndex == 2)
            {
                mc.switchTrack(2);
                questInstance1();
            }
            else
            {
                questInstance2();
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

}
