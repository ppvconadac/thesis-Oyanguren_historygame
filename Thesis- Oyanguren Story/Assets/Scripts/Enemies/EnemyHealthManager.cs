using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour {

    public int enemyMaxHealth;
    public int enemyCurrentHealth;
    public GameObject potion;
    public bool isDead;
    private experienceManager expm;
    public int expGiven;
    public bool isQuestMonster;
    public bool isQuestActive;
    private questMainPalawan qmp;
    private questMainl2 qml2;
    private side3Palawan s3p;
    public int dropchance;
    public GameObject[] attackCollider;
    int x = 0;

    // Use this for initialization
    void Start()
    {
        expm = FindObjectOfType<experienceManager>();
        enemyCurrentHealth = enemyMaxHealth;

        foreach (Transform child in transform)
            if (child.CompareTag("attackCollider"))
            {
                attackCollider[x] = child.gameObject;
                x++;
            } 
    

}

    // Update is called once per frame
    void Update()
    {
        if (enemyCurrentHealth <= 0)
        {
            if(isQuestActive && isQuestMonster)
            {
                if(FindObjectOfType<questMainPalawan>() != null)
                {
                    qmp = FindObjectOfType<questMainPalawan>();
                    qmp.wolfcount += 1;
                }
                else if (FindObjectOfType<questMainl2>() != null)
                {
                    qml2 = FindObjectOfType<questMainl2>();
                    qml2.wolfcount += 1;
                }
                
                
            }

            if(gameObject.transform.name == "Kapre")
            {
                s3p = FindObjectOfType<side3Palawan>();
                s3p.kapDefeated = true;

            }
            int x = Random.Range(0, dropchance);
            Debug.Log(x);
            if(x == 1) {
                var clone = (GameObject)Instantiate(potion, transform.position, transform.rotation);
                clone.SetActive(true);
            }
            expm.currentExperience += expGiven;
            Debug.Log(expm.currentExperience);
            for(int y = 0; y < attackCollider.Length; y++)
            {
                attackCollider[y].SetActive(false);
            }
            
            gameObject.SetActive(false);
            isDead = true;
            
        }
    }

    public void HurtEnemy(int damage)
    {
        enemyCurrentHealth -= damage;
        
    }

    public void SetMaxHealth()
    {
        enemyCurrentHealth = enemyMaxHealth;
    }

  

   
}
