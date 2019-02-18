﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenFader : MonoBehaviour {

    Animator anim;
    public bool isFading = false;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	void AnimationComplete()
    {
        isFading = false;
    }

    public IEnumerator FadeToBlack()
    {
        isFading = true;
        anim.SetTrigger("FadeOut");

        while (isFading)
        {
            yield return null;
        }
    }
    public IEnumerator FadeToClear()
    {
        isFading = true;
        anim.SetTrigger("FadeIn");

        while (isFading)
        {
            yield return null;
        }
    }

}
