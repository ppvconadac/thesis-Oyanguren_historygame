using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cut3 : MonoBehaviour
{

    private DialogueManager dMan;

    public string[] lines;
    public string[] charac;
    public string[] img;
    public Sprite[] images;
    private bool playerEnter;
    public bool istriggered;
    public CompanionController theCompanion;
    public questMainPalawan qmp;
    private PlayerMovement2 thePlayer;
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
    public playerRespawn pr;
    public pirateController[] piratesc;
    public EnemyDamageController[] edc;
    public zoneController zCont;
    private musicController mc;

    // Use this for initialization
    void Start()
    {
        
        dMan = FindObjectOfType<DialogueManager>();

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
        if (playerEnter)
        {
            if (!dMan.isreply)
            {
                dMan.textLines = lines;
                dMan.textimage = img;
                dMan.textName = charac;
                dMan.images = images;


                if (dMan.currentLine == 3)
                {
                    dMan.buttonActive = true;
                    btntext.text = btext;
                    btntext2.text = btext2;
                    btn1.SetActive(true);
                    btn2.SetActive(true);
                }

            

                    if (!dMan.dialogActive)
                    {

                        dMan.showDialogue();
                        dMan.currentLine = 0;
                       

                    }
                
            }
            else if (dMan.isreply)
            {

                dMan.textLines = Replines;
                dMan.textimage = Repimg;
                dMan.textName = Repcharac;
                istriggered = true;
                playerEnter = false;



            }
        }
       

        if (!dMan.dialogActive && istriggered)
        {
            
            zCont.zone1State(false);
            zCont.battleOn(true);
            thePlayer.incutscene = false;
            qmp.questCompleted();
            for (int x = 0; x < piratesc.Length; x++)
            {
                piratesc[x].canMove = true;
            }

            istriggered = false;
           
        }
        


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            mc.switchTrack(0);
            playerEnter = true;


        }
    }

    public void choosebtn()
    {
        Replines = Replines2;
        Repimg = Repimg2;
        Repcharac = Repcharac2;
        dMan.isreply = true;
        dMan.currentLine = -1;
        dMan.SkipToNextText();
        dMan.buttonActive = false;
        btn1.SetActive(false);
        btn2.SetActive(false);
        qmp.piratemax = 6;

    }
    public void choosebtn2()
    {
        for(int x = 0; x<edc.Length; x++)
        {
            edc[x].basedamage += 5;
        }
        dMan.isreply = true;
        dMan.currentLine = -1;
        dMan.SkipToNextText();
        dMan.buttonActive = false;
        btn1.SetActive(false);
        btn2.SetActive(false);
        qmp.piratemax = 100;
        pr.respawnon = false;
    }


}
