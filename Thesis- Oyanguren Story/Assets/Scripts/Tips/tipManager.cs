using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tipManager : MonoBehaviour {
	public bool istriggered;
	public GameObject tips;
	public Text tip;
	[TextArea]
	public string tiptext;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnTriggerStay2D (Collider2D other)
	{
		if(!istriggered){
			if(other.gameObject.tag== "Player")
       		{
            	tip.text = tiptext;
				tips.SetActive(true);
				istriggered = true;
      	 	}
		}
		
		
	}
}
