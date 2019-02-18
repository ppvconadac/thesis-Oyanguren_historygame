using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour {

    // Use this for initialization
    public Transform warpTarget;

    IEnumerator OnTriggerEnter2D(Collider2D other)
    {

        ScreenFader sf = GameObject.FindGameObjectWithTag("Fader").GetComponent<ScreenFader>();

        if (other.gameObject.tag == "Player")
        {
            yield return StartCoroutine(sf.FadeToBlack());
            other.gameObject.transform.position = warpTarget.position;
            yield return StartCoroutine(sf.FadeToClear());
        }

    }
}
