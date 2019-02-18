using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour {
    public GameObject thePlayer;
    private Vector3 targetPos;
    public float speed;

	// Use this for initialization
	void Start () {
        getTargetPos();
    }

    // Update is called once per frame
    void Update() {
        
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
    }

    public void getTargetPos()
    {
        targetPos = thePlayer.transform.position;
    }
}
