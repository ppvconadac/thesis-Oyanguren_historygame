using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicSwitcher : MonoBehaviour {

    private musicController mc;

    public int newTrack;
    public bool switchOnStart;
    public bool musicOnPlay;
    // Use this for initialization
    void Start () {
        mc = FindObjectOfType<musicController>();
        if (switchOnStart)
        {
            mc.switchTrack(newTrack);
            gameObject.SetActive(false);
        }
        else if (!musicOnPlay)
        {
            mc.musicCanPlay = false;
            gameObject.SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update () {
		if(mc == null)
        {
            mc = FindObjectOfType<musicController>();
        }
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            mc.switchTrack(newTrack);
            gameObject.SetActive(false);
        }
    }
}
