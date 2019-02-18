using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sword : MonoBehaviour {

    // Use this for initialization
    [SerializeField]
    private sfxManager sfxMan;
    [SerializeField]
    private DamageManager dm;

    void Update()
    {
        if(sfxMan == null)
        {
            sfxMan = FindObjectOfType<sfxManager>();
        }
        if (dm == null)
        {
            dm = FindObjectOfType<DamageManager>();
        }

      
    }

    // Use this for initialization
    private void OnTriggerEnter2D(Collider2D other)
    {
      

        if (other.gameObject.tag == "Player")
        {
            sfxMan.itemPick.Play();
            dm.levelUp();
            dm.levelUp();
            dm.levelUp();
            transform.gameObject.SetActive(false);
        }
    }
}
