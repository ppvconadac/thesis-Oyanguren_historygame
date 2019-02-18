using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class banana : MonoBehaviour {

    public questMainPalawan qmp;
    private sfxManager sfxMan;

    void Start()
    {
        sfxMan = FindObjectOfType<sfxManager>();
    }

    // Use this for initialization
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag== "Player")
        {
            sfxMan.itemPick.Play();
            qmp.bananaCount += 1;
            transform.gameObject.SetActive(false);
        }
    }
}
