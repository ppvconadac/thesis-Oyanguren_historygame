using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cut2loctrigger : MonoBehaviour {
    private DialogueManager dMan;

    public string[] lines;
    public string[] charac;
    public string[] img;
    public Sprite[] images;
    private bool playerEnter;
    public CompanionController theCompanion;
    private PlayerMovement2 thePlayer;
    public questMainPalawan qmp;
   
    public Transform pwarptarget;
    public bool istriggered;

    // Use this for initialization
    void Start () {
        dMan = FindObjectOfType<DialogueManager>();
    }
	
	// Update is called once per frame
	void Update () {
        if (thePlayer == null)
        {
            thePlayer = FindObjectOfType<PlayerMovement2>();
        }

        if (playerEnter)
        {
            
            theCompanion.canMove = false;
            dMan.textLines = lines;
            dMan.textimage = img;
            dMan.textName = charac;
            dMan.img = img;
            dMan.images = images;

            if (!dMan.dialogActive)
            {
                dMan.showDialogue();
                dMan.currentLine = 0;
                istriggered = true;
                playerEnter = false;
            }

        }

        if (!dMan.dialogActive && istriggered)
        {
            StartCoroutine("warptotarget");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Companion")
        {

            playerEnter = true;


        }
    }

   IEnumerator warptotarget()
    {
        istriggered = false;
        
        ScreenFader sf = GameObject.FindGameObjectWithTag("Fader").GetComponent<ScreenFader>();
        
      
      yield return StartCoroutine(sf.FadeToBlack());

        theCompanion.gameObject.SetActive(false);
         thePlayer.gameObject.transform.position = pwarptarget.position;
       
         thePlayer.anim.SetFloat("LastMoveX", 0f);
         thePlayer.anim.SetFloat("LastMoveY", 1f);
        
        yield return StartCoroutine(sf.FadeToClear());
        istriggered = false;

    }
}
