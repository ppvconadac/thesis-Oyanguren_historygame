using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zoneController : MonoBehaviour {
    public GameObject[] zoneSet1;
    public GameObject[] battleRestriction;
    // Use this for initialization
    public void zone1State(bool b)
    {
        
        for (int x = 0; x < zoneSet1.Length; x++)
        {

            zoneSet1[x].SetActive(b);
        }
    }

    public void battleOn(bool b)
    {
        for (int x = 0; x < battleRestriction.Length; x++)
        {
            battleRestriction[x].SetActive(b);
        }
       
    }
}
