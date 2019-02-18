using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public GameObject dBox;
    public GameObject image;
    public GameObject btn1;
    public GameObject btn2;
    public Text dText;
    public Text dtext2;
    public bool dialogActive;
    public Sprite[] images;
    public string[] img;
    public int currentLine = 0;
    public string[] textLines;
    public string[] textName;
    public string[] textimage;
    public bool buttonActive;
    public bool isreply;
    public Image background;

    public PlayerMovement thePlayer;

   
   // void Awake()
    //{
        //StartCoroutine(AnimateText());
   // }

    // Use this for initialization
    void Start()
    {
    
     
    }

    // Update is called once per frame
    void Update()
    {

        if (dialogActive && Input.GetKeyDown(KeyCode.Space) && !buttonActive)
        {
            SkipToNextText();
         
        }
        if(currentLine >= textLines.Length)
        {
            dBox.SetActive(false);
            dialogActive = false;
            currentLine = 0;

            if (isreply)
            {
                
                isreply = false;
                
            }
        }

        if (dialogActive)
        {
            
            int pic = int.Parse(textimage[currentLine]);
            image.GetComponent<Image>().sprite = images[pic];
            // dText.text = textName[currentLine] + ": " + textLines[currentLine];
            


        }

      
    }


    public void showDialogue()
    {
        dialogActive = true;
        dBox.SetActive(true);
        StartCoroutine(AnimateText());

    }

  

   public IEnumerator AnimateText()
    {

        for (int i = 0; i < (textLines[currentLine].Length + 1); i++)
        {
            
            dText.text= textName[currentLine] + ": " +  textLines[currentLine].Substring(0, i);
            yield return new WaitForSeconds(.03f);
        }
    }

    public void SkipToNextText()
    {
        StopAllCoroutines();
        currentLine++;
        //If we've reached the end of the array, do anything you want. I just restart the example text
        if (currentLine > textLines.Length)
        {
            currentLine = 0;
        }
        StartCoroutine(AnimateText());
    }

}
  