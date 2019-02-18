using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cut3sidetrigger : MonoBehaviour {

    private bool playerEnter;
    
    private PlayerMovement2 thePlayer;
    public side3Palawan qmp;

    public Transform pwarptarget;
    public bool istriggered;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(thePlayer== null)
        {
            thePlayer = FindObjectOfType<PlayerMovement2>();
        }

        if (playerEnter)
        {
            if (istriggered) {
                
                StartCoroutine("warptotarget");
                
            }
            

        }
            
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {

            playerEnter = true;
            istriggered = true;


        }
    }

    IEnumerator warptotarget()
    {
        playerEnter = false;
        istriggered = false;

        ScreenFader sf = GameObject.FindGameObjectWithTag("Fader").GetComponent<ScreenFader>();


        yield return StartCoroutine(sf.FadeToBlack());

        
        thePlayer.gameObject.transform.position = pwarptarget.position;

        thePlayer.anim.SetFloat("LastMoveX", 0f);
        thePlayer.anim.SetFloat("LastMoveY", -1f);

        yield return StartCoroutine(sf.FadeToClear());
        istriggered = false;

    }
}
