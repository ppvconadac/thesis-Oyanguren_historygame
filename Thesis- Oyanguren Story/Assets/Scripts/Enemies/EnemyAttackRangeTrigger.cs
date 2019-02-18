using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackRangeTrigger : MonoBehaviour {

    
    private WolfController parent;
    private pirateController parent2;
    // Use this for initialization
    void Start () {
        if(GetComponentInParent<WolfController>() != null)
        {
            parent = GetComponentInParent<WolfController>();
        }

        else
        {
            parent2 = GetComponentInParent<pirateController>();
        }
       
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerStay2D(Collider2D other)
    {

        {
            if (other.CompareTag("Player"))
            {

                if (parent != null)
                {
                    parent.isattacking = true;
                    parent.attackInstance = 1;
                }
                else
                {
                    parent2.isattacking = true;
                    parent2.attackInstance = 1;
                }
                
                
            }
        }
    }

   


}
