using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartPoint : MonoBehaviour {

    private PlayerMovement2 thePlayer;
    private CameraController2 theCamera;
    public Vector2 startDirection;
	// Use this for initialization
	void Start () {
       
        
    }
	
	// Update is called once per frame
	void Update () {
		if(thePlayer == null)
        {
            thePlayer = FindObjectOfType<PlayerMovement2>();
            thePlayer.transform.position = transform.position;
            thePlayer.lastMove = startDirection;
        }

        if(theCamera == null)
            {
            theCamera = FindObjectOfType<CameraController2>();
            theCamera.transform.position = new Vector3(transform.position.x, transform.position.y, theCamera.transform.position.z);
        }
	}
}
