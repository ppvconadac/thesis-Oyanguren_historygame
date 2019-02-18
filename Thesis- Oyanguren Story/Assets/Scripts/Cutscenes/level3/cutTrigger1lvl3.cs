﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cutTrigger1lvl3 : MonoBehaviour {

    // Use this for initialization
    private DialogueManager dMan;

    public string[] lines;
    public string[] charac;
    public string[] img;
    public Sprite[] images;
    private bool playerEnter;

    private bool dialogOngoing;
    public bool istriggered;
    public questMainl3 qmp;
    public QuestManager qm;



    // Use this for initialization
    void Start()
    {

        dMan = FindObjectOfType<DialogueManager>();


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

            qm.mainqactive = true;
            qm.questActivated();
            qm.buttonMain.gameObject.SetActive(true);
            qmp.questActive = true;
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