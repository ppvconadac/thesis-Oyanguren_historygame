using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanionController : MonoBehaviour {

    public float moveSpeed;
    public Animator anim;

    public Rigidbody2D myRigidbody;

    public bool isWalking;
    public float walkTime;
    public float waitTime;
    private float walkCounter;
    private float waitCounter;
    public bool canMove;
    private bool inZone;

    private int walkDirection;
    public Transform target;
    private Vector2 minWalkPoint;
    private Vector2 maxWalkPoint;
    public bool hasWalkZone;

    public Collider2D walkZone;

    public bool incutscene;
    public Vector3 moveDirection;


    // Use this for initialization
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
        waitCounter = waitTime;
        walkCounter = walkTime;
        canMove = false;
        anim.SetFloat("LastMoveX", 1);

        if (walkZone != null)
        {
            minWalkPoint = walkZone.bounds.min;
            maxWalkPoint = walkZone.bounds.max;
            hasWalkZone = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        

        if (!canMove)
        {
            
            myRigidbody.velocity = Vector2.zero;
            anim.SetBool("isWalking", false);
            return;

        }

        if (incutscene)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            moveDirection.x = -(transform.position.x - target.position.x);
            moveDirection.y = -(transform.position.y - target.position.y);
            anim.SetBool("isWalking", true);
            anim.SetFloat("MoveX", moveDirection.x);
            anim.SetFloat("MoveY", moveDirection.y);
            anim.SetFloat("LastMoveX", moveDirection.x);
            anim.SetFloat("LastMoveY", moveDirection.y);
            return;
        }

        else
        {
            if (isWalking)
            {

                walkCounter -= Time.deltaTime;


                switch (walkDirection)
                {
                    case 0:
                        if (hasWalkZone && transform.position.y >= maxWalkPoint.y)
                        {
                            isWalking = false;
                            waitCounter = waitTime;
                        }
                        myRigidbody.velocity = new Vector2(0, moveSpeed);
                        moveDirection = myRigidbody.velocity;
                        anim.SetFloat("LastMoveY", moveDirection.y);
                        break;
                    case 1:

                        if (hasWalkZone && transform.position.x >= maxWalkPoint.x)
                        {
                            isWalking = false;
                            waitCounter = waitTime;
                        }
                        myRigidbody.velocity = new Vector2(moveSpeed, 0);
                        moveDirection = myRigidbody.velocity;
                        anim.SetFloat("LastMoveX", moveDirection.x);
                        break;
                    case 2:
                        if (hasWalkZone && transform.position.y <= minWalkPoint.y)
                        {
                            isWalking = false;
                            waitCounter = waitTime;
                        }
                        myRigidbody.velocity = new Vector2(0, -moveSpeed);
                        moveDirection = myRigidbody.velocity;
                        anim.SetFloat("LastMoveY", moveDirection.y);
                        break;
                    case 3:
                        if (hasWalkZone && transform.position.x <= minWalkPoint.x)
                        {
                            isWalking = false;
                            waitCounter = waitTime;
                        }
                        myRigidbody.velocity = new Vector2(-moveSpeed, 0);
                        moveDirection = myRigidbody.velocity;
                        anim.SetFloat("LastMoveX", moveDirection.x);
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
                if (waitCounter < 0)
                {
                    ChooseDirection();
                }
            }

          anim.SetFloat("MoveX", moveDirection.x);
        anim.SetFloat("MoveY", moveDirection.y);
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

