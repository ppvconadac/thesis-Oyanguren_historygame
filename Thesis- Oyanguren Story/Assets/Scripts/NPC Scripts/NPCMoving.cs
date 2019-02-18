using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMoving : MonoBehaviour {

    public float moveSpeed;
    private Animator anim;

    public Rigidbody2D myRigidbody;

    public bool isWalking;
    public float walkTime;
    public float waitTime;
    private float walkCounter;
    private float waitCounter;
    public bool canMove;
    private bool inZone;

    private int walkDirection;

    private Vector2 minWalkPoint;
    private Vector2 maxWalkPoint;
    private bool hasWalkZone;

    public Collider2D walkZone;

   
	// Use this for initialization
	void Start () {
        myRigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
        waitCounter = waitTime;
        walkCounter = walkTime;
        ChooseDirection();

        if (walkZone != null)
        {
            minWalkPoint = walkZone.bounds.min;
            maxWalkPoint = walkZone.bounds.max;
            hasWalkZone = true;
        }
	}
	
	// Update is called once per frame
	void Update () {

        if (!canMove)
        {

            myRigidbody.velocity = Vector2.zero;
            anim.SetBool("isWalking", false);
            return;

        }

        else { 
        if (isWalking)
        {

            walkCounter -= Time.deltaTime;
           

            switch (walkDirection)
            {
                case 0:
                    if(hasWalkZone && transform.position.y >= maxWalkPoint.y)
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                    }
                    myRigidbody.velocity = new Vector2(0, moveSpeed);
                    anim.SetFloat("LastMoveY", myRigidbody.velocity.y);
                    break;
                case 1:

                    if (hasWalkZone && transform.position.x >= maxWalkPoint.x)
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                    }
                    myRigidbody.velocity = new Vector2(moveSpeed,0);
                    anim.SetFloat("LastMoveX", myRigidbody.velocity.x);
                    break;
                case 2:
                    if (hasWalkZone && transform.position.y <= minWalkPoint.y)
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                    }
                    myRigidbody.velocity = new Vector2(0, -moveSpeed);
                    anim.SetFloat("LastMoveY", myRigidbody.velocity.y);
                    break;
                case 3:
                    if (hasWalkZone && transform.position.x <= minWalkPoint.x)
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                    }
                    myRigidbody.velocity = new Vector2(-moveSpeed, 0);
                    anim.SetFloat("LastMoveX", myRigidbody.velocity.x);
                    break;

            }

            if (walkCounter < 0)
            {
                isWalking = false;
                waitCounter = waitTime;
            }
        }
        else
        {
            waitCounter -= Time.deltaTime;
            myRigidbody.velocity = Vector2.zero;
            if(waitCounter < 0)
            {
                ChooseDirection();
            }
        }

        anim.SetFloat("MoveX", myRigidbody.velocity.x);
        anim.SetFloat("MoveY", myRigidbody.velocity.y);
        anim.SetBool("isWalking", isWalking);

        }

    }

    public void ChooseDirection()
    {
        canMove = true;
        walkDirection = Random.Range(0, 4);
        isWalking = true;
        walkCounter = walkTime;
    }
}
