using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WolfController : MonoBehaviour {

    public float moveSpeed;

    public Rigidbody2D myRigidbody;
    public bool moving;
    public float timeBetweenMove;
    private float timeBetweenMoveCounter;
    public float timeToMove;
    private float timeToMoveCounter;
    private Vector3 moveDirection;
    private Animator anim;
    public float waitToReload;
    private bool reloading;
    private GameObject thePlayer;
    public Vector3 initial;
    public bool chaseactive;
    public bool isattacking;

    public int attackInstance;
    

    private bool backtoinit;

    private Transform target;

    public Transform Target
    {
        get
        {
            return target;
        }

        set
        {
            target = value;
        }
    }

    

    // Use this for initialization
    void Start () {
        myRigidbody = GetComponent<Rigidbody2D>();

        //timeBetweenMoveCounter = timeBetweenMove;
        //timeToMoveCounter = timeToMove;
        anim = GetComponent<Animator>();

        timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
        timeToMoveCounter = Random.Range(timeToMove * 0.75f, timeToMove * 1.25f);
	}
	
	// Update is called once per frame
	void Update () {
        if (isattacking)
        {
            chaseactive = false;
            if(attackInstance > 0)
            {
                myRigidbody.velocity = Vector2.zero;
                anim.SetBool("WolfMoving", false);
                anim.SetBool("WolfAttacking", true);
                myRigidbody.bodyType = RigidbodyType2D.Kinematic;
     
            }

            else
            {
                anim.SetBool("WolfAttacking", false);
                isattacking = false;
                myRigidbody.bodyType = RigidbodyType2D.Dynamic;
                
                
            }


            
                
           
        }
        else
        {

            
            if (chaseactive)
            {
                FollowTarget();

            }
            else
            {

                if (moving)
                {

                    timeToMoveCounter -= Time.deltaTime;
                    myRigidbody.velocity = moveDirection;

                    if (timeToMoveCounter < 0f)
                    {
                        moving = false;
                        //timeBetweenMoveCounter = timeBetweenMove;
                        timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
                    }
                }

                else
                {
                    timeBetweenMoveCounter -= Time.deltaTime;
                    myRigidbody.velocity = Vector2.zero;
                    if (timeBetweenMoveCounter < 0f)
                    {
                        moving = true;
                        //timeToMoveCounter = timeToMove;
                        timeToMoveCounter = Random.Range(timeToMove * 0.75f, timeToMove * 1.25f);
                        float direction = Random.Range(0f,1f);
                        
                        
                        
                            moveDirection = new Vector3(Random.Range(-1f, 1f) * moveSpeed, Random.Range(-1f, 1f) * moveSpeed, 0f);
                       
                        
                    }
                }
                if (System.Math.Abs(moveDirection.x) > System.Math.Abs(moveDirection.y))
                {
                    anim.SetFloat("LastMoveX", moveDirection.x);
                }
                else
                {
                    anim.SetFloat("LastMoveY", moveDirection.y);
                }

                anim.SetFloat("MoveX", moveDirection.x);
                anim.SetFloat("MoveY", moveDirection.y);
                anim.SetBool("WolfMoving", moving);
                
            }
        }
        if (reloading)
        {
            waitToReload -= Time.deltaTime;
            if(waitToReload < 0)
            {
                SceneManager.LoadScene("west_forest");
                thePlayer.SetActive(true);
            }
        }

        


    }


    private void OnCollisionEnter2D(Collision2D other)
    {

       //if(other.gameObject.name == "Player_2")
       //{
            //other.gameObject.SetActive(false);
            //reloading = true;
            //thePlayer = other.gameObject;
            
       //}
    }

    private void FollowTarget()
    {   
        moving = true;
        if(backtoinit==false)
        {
            
            transform.position = Vector2.MoveTowards(transform.position, initial, moveSpeed * Time.deltaTime);
            moveDirection.x = -(transform.position.x - initial.x);
            moveDirection.y = -(transform.position.y - initial.y);

            if(transform.position.Equals(initial))
            {
                
                backtoinit = true;
                chaseactive = false;
            }
        }

        if (System.Math.Abs(transform.position.x - initial.x) > 250 || System.Math.Abs(transform.position.y - initial.y) > 250)
        {

           backtoinit = false;
           target = null;
            //chaseactive = false;
                 
         
            
        }

        if (target != null)
        {
            StartCoroutine("Chase");
        }

            
        
        anim.SetFloat("MoveX", moveDirection.x);
        anim.SetFloat("MoveY", moveDirection.y);
        anim.SetBool("WolfMoving", moving);
    }

    private IEnumerator Chase()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        moveDirection.x = -(transform.position.x - target.position.x);
        moveDirection.y = -(transform.position.y - target.position.y);

        yield return null;
    }

    private void attackinstancesub()
    {
        attackInstance -= 1;
    }

    
}
