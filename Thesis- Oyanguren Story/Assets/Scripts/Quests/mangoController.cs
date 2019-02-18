using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mangoController : MonoBehaviour
{

    // Use this for initialization
    public GameObject[] mangoes;

    // Use this for initialization
    public void setMangoActive()
    {
        for (int x = 0; x < mangoes.Length; x++)
        {
            mangoes[x].SetActive(true);
        }
    }
}

