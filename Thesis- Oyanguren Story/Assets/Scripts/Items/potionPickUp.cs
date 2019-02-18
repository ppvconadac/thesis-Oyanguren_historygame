using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class potionPickUp : MonoBehaviour {

    private PlayerHealthManager phm;
    private sfxManager sfxMan;

    void Start()
    {
        sfxMan = FindObjectOfType<sfxManager>();
    }

    // Use this for initialization
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(phm == null)
        {
            phm = FindObjectOfType<PlayerHealthManager>();

        }
        if(other.gameObject.tag == "Player")
        {
            sfxMan.potionPick.Play();
            phm.playerCurrentHealth += 20;
            Destroy(gameObject);
        }
    }
}
