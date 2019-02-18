using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnSpiders : MonoBehaviour {

    public float spawntime;
    public float spawntimer;
    public GameObject spider;

	// Use this for initialization
	void Start () {
        spawntimer = spawntime;
	}
	
	// Update is called once per frame
	void Update () {
		

        if(spawntimer <= 0)
        {
            var clone = (GameObject)Instantiate(spider, transform.position, transform.rotation);
            clone.SetActive(true);
            spawntimer = spawntime;
        }
        if(spawntimer> 0)
        {
            spawntimer -= Time.deltaTime;
        }
	}
}
