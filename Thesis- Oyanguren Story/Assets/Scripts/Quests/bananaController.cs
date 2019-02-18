using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bananaController : MonoBehaviour {

    public GameObject[] bananas;

	// Use this for initialization
	public void setBananaActive()
    {
        for(int x= 0; x< bananas.Length; x++)
        {
            bananas[x].SetActive(true);
        }
    }


}
