using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour {

    public GameObject questlog;
    
    private bool qlogactive;
    public bool mainqactive = false;
    public Text questDesc;
    public Text questProg;
    public Text questTitle;
    public bool side1active = false;
    public bool side2active = false;
    public bool side3active = false;
    public int mainindex;
    public int side1index;
    public int side2index;
    public int side3index;
    public GameObject buttonMain;
    public GameObject side1btn;
    public GameObject side2btn;
    public GameObject side3btn;
    public Image qactivate;

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
       
        if (!qlogactive)
        {

            if (Input.GetKeyDown(KeyCode.U))
            {
                questlog.SetActive(true);
                questTitle.text = "";
                questDesc.text = "Select a Quest to view details";
                questProg.text = "";
                qlogactive = true;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.U))
            {
                questlog.SetActive(false);
                qlogactive = false;
            }
        }

    }

    public void questActivated()
    {
        qactivate.gameObject.SetActive(true);

    }

   

}
