using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cgManager : MonoBehaviour
{
    public GameObject cgBox;
    public GameObject CG;
    public GameObject cgDbox;
    public Text dText;
    public bool cgActive;
    public Sprite[] images;
    public string[] img;
    public int currentLine;
    public string[] textLines;
    public string[] textName;
    public string[] textimage;
   

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (cgActive && Input.GetKeyDown(KeyCode.Space))
        {
            SkipToNextText();

        }
        if (currentLine >= textLines.Length)
        {
            cgBox.SetActive(false);
            cgActive = false;
            currentLine = 0;


        }

        if (cgActive)
        {

            int pic = int.Parse(textimage[currentLine]);
            CG.GetComponent<Image>().sprite = images[pic];
   
               

        }


    }


    public void showDialogue()
    {
        cgActive = true;
        cgBox.SetActive(true);
        StartCoroutine(AnimateText());
    }

    IEnumerator AnimateText()
    {

        for (int i = 0; i < (textLines[currentLine].Length + 1); i++)
        {
            dText.text = textLines[currentLine].Substring(0, i);
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


