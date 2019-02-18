using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class side1Palawan : MonoBehaviour
{
    public string[] questTitle;
    public string[] questDesc;
    public string[] questProg;
    public bool[] isCompleted;
    public bool questActive;
    public int questIndex;
    public QuestManager qm;
    public Image questupdated;
    public Image questcomp;
    public int mangoCount;
    private DialogueManager dMan;
    public experienceManager xpm;
    public PlayerHealthManager phm;
    // Use this for initialization
    void Start()
    {
        dMan = FindObjectOfType<DialogueManager>();

        questProg = new string[questTitle.Length];
        isCompleted = new bool[questTitle.Length];
    }

    // Update is called once per frame
    void Update()
    {
        if (xpm == null)
        {
            xpm = FindObjectOfType<experienceManager>();
        }
        if (phm == null)
        {
            phm = FindObjectOfType<PlayerHealthManager>();
        }
        if (questIndex == 0)
        {

            if (mangoCount == 5)
            {
                questCompleted();
            }
        }

      
    }

    public void questCompleted()
    {
       if(questIndex == questTitle.Length - 1)
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

        if(questIndex == questTitle.Length)
        {
            xpm.currentExperience += questTitle.Length * 10 / 2;
            phm.playerCurrentHealth = phm.playerMaxHealth;
            
        }

    }

    public void onClickSide1()
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
            if(questIndex < questTitle.Length)
            {
                qm.questTitle.text = questTitle[questIndex];
                qm.questDesc.text = questDesc[questIndex];
                qm.questProg.text = questProg[questIndex];

                if (questIndex == 0)
                {
                    questProg[questIndex] = "Mangoes Collected : " + mangoCount + "/5";
                    qm.questProg.text = questProg[questIndex];

                }
            }
           
            else if (questIndex == questTitle.Length)
            {
                qm.questTitle.text = "Quest Completed";
                qm.questDesc.text = "Rewards: " + "\n" + questTitle.Length * 10 / 2 + " xp" + "\n" + "Fruit(HP Max)";
                qm.questProg.text = "";
            }
           
        }
    }
}
