using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class batControllerReverse : MonoBehaviour
{

    // Use this for initialization
    float angle = 0;
    float speed = (2 * Mathf.PI) / 3f; //2*PI in degress is 360, so you get 5 seconds to complete a circle
    public float radius;
    private Vector3 movedirection;
    private Rigidbody2D myRigidbody;
    // Use this for initialization
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        myRigidbody.velocity = movedirection;
        angle -= speed * Time.deltaTime; //if you want to switch direction, use -= instead of +=
        float x = Mathf.Cos(angle) * radius;
        float y = Mathf.Sin(angle) * radius;

        movedirection = new Vector3(x, y / 2);

    }

}
