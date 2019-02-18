using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class questMainl3 : MonoBehaviour {

    // Use this for initialization
    public string[] questTitle;
    public string[] questDesc;
    public string[] questProg;
    public bool[] isCompleted;
    public bool questActive;
    public int questIndex;
    public QuestManager qm;
    public Image questupdated;

    public int wolfcount;
   


    private DialogueManager dMan;
    public string[] lines;
    public string[] charac;
    public string[] img;
    public Sprite[] images;
    public bool istriggered;

    private experienceManager xpm;
    public Image questcomp;

    // Use this for initialization
    void Start()
    {
        dMan = FindObjectOfType<DialogueManager>();
        xpm = FindObjectOfType<experienceManager>();
        questProg = new string[questTitle.Length];
        isCompleted = new bool[questTitle.Length];
        qm.mainqactive = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (xpm == null)
        {
            xpm = FindObjectOfType<experienceManager>();
        }
        if (questIndex == 1)
        {
            if(wolfcount == 8)
            {
                questCompleted();
            }
        }
       
    }

    public void questCompleted()
    {
        if (questIndex == questTitle.Length -1)
        {
            questcomp.gameObject.SetActive(true);
        }
        else
        {
            questupdated.gameObject.SetActive(true);
        }
        xpm.currentExperience += 10;
        isCompleted[questIndex] = true;
        questIndex++;

        if (questIndex == questTitle.Length)
        {
            xpm.currentExperience += questTitle.Length * 10 / 2;


        }

    }

    public void onClickMain()
    {
        Debug.Log("clicked");
        if (!questActive)
        {
            qm.questTitle.text = "";
            qm.questDesc.text = "Quest currently inactive";
            qm.questProg.text = "";
        }
        else
        {
            qm.questTitle.text = questTitle[questIndex];
            qm.questDesc.text = questDesc[questIndex];
            qm.questProg.text = questProg[questIndex];

            if (questIndex == 2)
            {
                questProg[questIndex] = "Wood Collected" + wolfcount + "/8";
                qm.questProg.text = questProg[questIndex];

            }
            else if (questIndex == questTitle.Length)
            {
                qm.questTitle.text = "Quest Completed";
                qm.questDesc.text = "Rewards: " + "\n" + questTitle.Length * 10 / 2 + " xp";
                qm.questProg.text = "";
            }
        }
    }


}
