using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sortingLayerChange : MonoBehaviour {
    private Vector3 playerPos;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnCollisionEnter2D(Collision2D collision)
    {
        playerPos = collision.transform.position;
        if(collision.gameObject.tag == "Player")
        {
            if(playerPos.y > transform.position.y)
            {
                GetComponent<SpriteRenderer>().sortingOrder = 1;
            }
            else
            {
                GetComponent<SpriteRenderer>().sortingOrder = 0;
            }
        }
    }
}
