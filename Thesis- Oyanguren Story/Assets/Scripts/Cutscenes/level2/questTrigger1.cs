using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class questTrigger1 : MonoBehaviour {


	private questMainl2 qml2;
	// Use this for initialization
	void Start () {
		qml2 = FindObjectOfType<questMainl2>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	 private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {

           qml2.questCompleted();
           gameObject.SetActive(false);

        }
    }
}
