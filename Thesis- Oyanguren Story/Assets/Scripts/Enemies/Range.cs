using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Range : MonoBehaviour {

    private WolfController parent;
    private Vector3 playerPos;

    // Use this for initialization
    void Start () {
        parent = GetComponentInParent<WolfController>();
	}

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.name == "Player_2")
        {
            parent.myRigidbody.velocity = Vector2.zero;
            parent.Target = other.transform;
            parent.chaseactive = true;
            parent.initial = parent.transform.position;
            
        }
        playerPos = other.transform.position;
        if (other.gameObject.tag == "Player")
        {
            if (playerPos.y > transform.position.y)
            {
                GetComponentInParent<SpriteRenderer>().sortingOrder = 1;
            }
            else
            {
                GetComponentInParent<SpriteRenderer>().sortingOrder = 0;
            }
        }
    }

    // Update is called once per frame
    
}
