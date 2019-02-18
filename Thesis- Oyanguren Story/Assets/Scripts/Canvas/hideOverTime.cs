using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hideOverTime : MonoBehaviour {
    public float timeToHide;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timeToHide -= Time.deltaTime;

        if (timeToHide <= 0)
        {
            gameObject.SetActive(false);
            timeToHide = 2;
        }
    }
}
