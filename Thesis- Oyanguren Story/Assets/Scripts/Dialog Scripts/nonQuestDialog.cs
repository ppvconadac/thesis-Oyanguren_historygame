using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class nonQuestDialog : MonoBehaviour {


    private DialogueManager dMan;

    public string[] lines;
    public string[] charac;
    public string[] img;
    public Sprite[] images;
    private bool playerEnter;
    // Use this for initialization
    void Start () {
        dMan = FindObjectOfType<DialogueManager>();
    }
	
	// Update is called once per frame
	void Update () {
        


        if (Input.GetKeyDown(KeyCode.E) && playerEnter)
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerEnter = true;
            Debug.Log("Hello");
            

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerEnter = false;
           
        }
    }
}
