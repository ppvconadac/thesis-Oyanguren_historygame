using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cut1 : MonoBehaviour
{

    private DialogueManager dMan;

    public string[] lines;
    public string[] charac;
    public string[] img;
    public Sprite[] images;
    private bool playerEnter;
    public Transform target;
    private bool dialogOngoing;
    public bool istriggered;
    private CompanionController theCompanion;
    private CompanionDialogRange cdr;
    public questMainPalawan qmp;
    public QuestManager qm;
    public GameObject tips;
    public Text tip;
    [TextArea]
    public string tiptext;


    // Use this for initialization
    void Start()
    {
        theCompanion = FindObjectOfType<CompanionController>();
        dMan = FindObjectOfType<DialogueManager>();
        cdr = FindObjectOfType<CompanionDialogRange>();

    }

    // Update is called once per frame
    void Update()
    {
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
            
            theCompanion.incutscene = true;
            theCompanion.target = target;
            theCompanion.canMove = true;
            theCompanion.isWalking = true;
            cdr.triggeractive = true;
            qm.mainqactive = true;
            qm.questActivated();
            qm.buttonMain.gameObject.SetActive(true);
            qmp.questActive = true;
            tip.text = tiptext;
            tips.SetActive(true);
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
