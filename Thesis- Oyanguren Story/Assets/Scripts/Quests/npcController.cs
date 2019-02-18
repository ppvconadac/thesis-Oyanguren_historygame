using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcController : MonoBehaviour {

    public GameObject[] npcSet1;
    public GameObject[] npcSet2;
  
    // Use this for initialization
    public void set1State(bool b)
    {
        for (int x = 0; x < npcSet1.Length; x++)
        {
            npcSet1[x].SetActive(b);
        }
    }

    public void set2State(bool b)
    {
        for (int x = 0; x < npcSet2.Length; x++)
        {
            npcSet2[x].SetActive(b);
            
        }

        


    }

}
