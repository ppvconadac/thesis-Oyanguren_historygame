using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kapreRange2 : MonoBehaviour {

    // Use this for initialization
    private kapreController kapMove;

    // Use this for initialization
    void Start()
    {
        kapMove = GetComponentInParent<kapreController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            kapMove.area2 = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            kapMove.area2 = false;
        }
    }
}
