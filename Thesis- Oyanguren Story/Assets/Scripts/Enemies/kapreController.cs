using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kapreController : MonoBehaviour {

    public bool area1;
    public bool area2;
    public float cooldown1;
    public float cooldown2;
    public float aftercastdelay;
    public float castdelaytimer;
    public bool cancast;
    public bool casted;
    private Animator anim;
    public GameObject spell1;
    public GameObject fireball;
    public Transform shotPoint;
    private sfxManager sfMan;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        sfMan = FindObjectOfType<sfxManager>();
        area1 = false;
        area2 = false;
        cancast = false;
        casted = false;
        
    }
	
	// Update is called once per frame
	void Update () {


        if (!cancast)
        {
            anim.SetBool("isCasting", false);

            if (area1 == true || area2 == true && castdelaytimer <= 0 && casted == false)
            {
                
                cast();
            }

        }
        else
        {

            if (castdelaytimer > 0 && casted)
            {
                castdelaytimer -= Time.deltaTime;

            }
            if (castdelaytimer <= 0 && casted)
            {
                anim.SetBool("isCasting", false);
                cancast = false;
                casted = false;
            }
        }
       


           
        

       


    }

    public void cast()
    {
        anim.SetBool("isCasting", true); 
        castdelaytimer = aftercastdelay;
        casted = true;
        cancast = true;
        

    }
    public void spell()
    {
        if(area1 == true)
        {
            sfMan.fireExplosion.Play();
            spell1.SetActive(true);
            
        }
        else
        {
            var clone = (GameObject)Instantiate(fireball, shotPoint.position, transform.rotation);
            clone.SetActive(true);
        }
    }

    public void castAudio()
    {
        sfMan.fireCrackle.Play();
    }


}
