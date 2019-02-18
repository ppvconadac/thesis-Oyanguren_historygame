using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyRespawn : MonoBehaviour {

    public EnemyHealthManager ehm;
    public float respawntime;
    public float currentrestime;

    // Use this for initialization
    void Start () {
        currentrestime = respawntime;
	}
	
	// Update is called once per frame
	void Update () {
        if (ehm.isDead)
        {
            if (currentrestime > 0)
            {
                currentrestime -= Time.deltaTime;
            }

            if (currentrestime <= 0)
            {
                ehm.enemyCurrentHealth = ehm.enemyMaxHealth;
                ehm.transform.position = transform.position;
                ehm.gameObject.SetActive(true);
                ehm.isDead = false;
                currentrestime = respawntime;
            }
        }
	}
}
