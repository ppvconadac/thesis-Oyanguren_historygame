using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageManager : MonoBehaviour {
    public int basedamage;
	// Use this for initialization
	void Start () {
        basedamage = 9;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void levelUp()
    {
        basedamage += 1;

    }
}
