using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour {

    public int damage;
    public GameObject damageBurst;
    public GameObject damageNumber;
    
    public Transform hitPoint;
    public Transform bursthitPoint;
    public experienceManager xpm;
    public DamageManager dm;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter2D(Collider2D other)
    {

        {
            if (other.CompareTag("Enemy") || other.CompareTag("Enemy_HitBox")) 
            {
                damage = dm.basedamage + (Random.Range(0, 3));
                if (other.CompareTag("Enemy"))
                {
                    other.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(damage);
                }
                else
                {
                    other.gameObject.GetComponentInParent<EnemyHealthManager>().HurtEnemy(damage);
                }
                
                var clone = (GameObject)Instantiate(damageNumber, other.transform.position, Quaternion.Euler(Vector3.zero));
                clone.GetComponent<DamageNumbers>().damageNumber = damage;
                Instantiate(damageBurst, bursthitPoint.position, transform.rotation);
                
            }
            
         
        }
    }
}
