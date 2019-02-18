using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cut1loctrigger : MonoBehaviour {

    private CompanionController theCompanion;
    private cut1 cut;
    // Use this for initialization
    

    void Start()
    {
        theCompanion = FindObjectOfType<CompanionController>();
        cut = FindObjectOfType<cut1>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Companion")
        {
            cut.istriggered = false;
            Debug.Log("in");
            theCompanion.incutscene = false;

            theCompanion.hasWalkZone = true;
            theCompanion.canMove = true;
            theCompanion.ChooseDirection();
            transform.gameObject.SetActive(false);
        }
    }
}
