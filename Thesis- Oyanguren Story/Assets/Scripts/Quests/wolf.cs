using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wolf : MonoBehaviour {

    public EnemyHealthManager[] ehm;
    public questMainPalawan qmp;

	// Use this for initialization
	void Start () {
        
        if(ehm != null)
        {
            for (int x = 0; x < ehm.Length; x++)
            {

                ehm[x].isQuestMonster = true;
            }
        }
       
	}
	
	// Update is called once per frame
	void Update () {

        if (ehm != null)
        {
            for (int x = 0; x < ehm.Length; x++)
            {

                ehm[x].isQuestMonster = true;
            }
            if (qmp.questIndex == 5 || qmp.questIndex == 7)
            {
                for (int x = 0; x < ehm.Length; x++)
                {
                    ehm[x].isQuestActive = true;
                }

            }
            else
            {

                for (int x = 0; x < ehm.Length; x++)
                {
                    ehm[x].isQuestActive = false;
                }

            }
        }
        

	}
}
