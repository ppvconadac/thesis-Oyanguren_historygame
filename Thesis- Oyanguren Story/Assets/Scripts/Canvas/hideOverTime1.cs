using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hideOverTime1 : MonoBehaviour {

	// Use this for initialization
	public float timeToDestroy;
	public float currentTimeToDestroy;
	// Use this for initialization
	void Start () {
		currentTimeToDestroy = timeToDestroy;
	}
	
	// Update is called once per frame
	void Update () {
        currentTimeToDestroy -= Time.deltaTime;

        if(currentTimeToDestroy <= 0)
        {
            gameObject.SetActive(false);
            currentTimeToDestroy = timeToDestroy;

        }
	}
}
