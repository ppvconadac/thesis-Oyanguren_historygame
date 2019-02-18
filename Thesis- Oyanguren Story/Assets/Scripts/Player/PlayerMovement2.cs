using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{
    private Rigidbody2D myRigidbody;
    public float moveSpeed;
    public Animator anim;
    private bool playerMoving;
    public Vector2 lastMove;
    private static bool exists;
    private bool attacking;
    public float attackTime;
    private float attackTimeCounter;
    private DamageController dmgctrl;
    public bool canMove;
    private ScreenFader sf;
    private DialogueManager dm;
    public bool incutscene;
    private sfxManager sfxMan;

    

    // Use this for initialization
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sf = FindObjectOfType<ScreenFader>();
        dm = FindObjectOfType<DialogueManager>();
        sfxMan = FindObjectOfType<sfxManager>();

        if (!exists)
        {
            exists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        sf = FindObjectOfType<ScreenFader>();
        dm = FindObjectOfType<DialogueManager>();
        
        if (sf.isFading || dm.dialogActive || incutscene)
        {
            canMove = false;
        }
        else
        {
            canMove = true;
        }

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            moveSpeed = 160;
        }
        else
        {
            moveSpeed = 70;
        }

        if (!canMove)
        {
            myRigidbody.velocity = Vector2.zero;
            anim.SetBool("PlayerMoving", false);
            anim.SetBool("PlayerAttacking", false);
            return;
        }
        if (!attacking)
        {

            playerMoving = false;
            if (Input.GetAxisRaw("Horizontal") > 0f || Input.GetAxisRaw("Horizontal") < -0f)
            {
                //transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
                playerMoving = true; 
                myRigidbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, myRigidbody.velocity.y);
                lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
            }

            if (Input.GetAxisRaw("Vertical") > 0 || Input.GetAxisRaw("Vertical") < -0f)
            {
                //transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, Input.GetAxisRaw("Vertical") * moveSpeed);
                playerMoving = true;
                lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
            }

            if (Input.GetAxisRaw("Horizontal") < 0.5f && Input.GetAxisRaw("Horizontal") > -0.5f)
            {
                myRigidbody.velocity = new Vector2(0f, myRigidbody.velocity.y);
            }

            if (Input.GetAxisRaw("Vertical") < 0.5f && Input.GetAxisRaw("Vertical") > -0.5f)
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, 0f);
            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                attackTimeCounter = attackTime;
                attacking = true;
                myRigidbody.velocity = Vector2.zero;
                anim.SetBool("PlayerAttacking", true);
                sfxMan.swordSwing.Play();
            }



        }
        if (attackTimeCounter > 0)
        {
            attackTimeCounter -= Time.deltaTime;

        }

        if (attackTimeCounter <= 0)
        {
            attacking = false;
            anim.SetBool("PlayerAttacking", false);
        }

        anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        anim.SetBool("PlayerMoving", playerMoving);
        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.y);


    }

  



}


