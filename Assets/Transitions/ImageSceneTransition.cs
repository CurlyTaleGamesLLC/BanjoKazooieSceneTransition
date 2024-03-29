﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageSceneTransition : MonoBehaviour
{

    public Material mat;
    float propertyValue = 0f;
    bool isFadeOut = false;

    void Start(){
        FadeIn();
    }

    public void FadeIn(){
        isFadeOut = false;
        UpdateMaterial(1f);
        AnimateProperty(1f, 0f);
    }

     public void FadeOut(){
        isFadeOut = true;
        UpdateMaterial(0f);
        AnimateProperty(1f, 1f);
    }

    //iTween documentation
    //http://www.pixelplacement.com/itween/documentation.php
    public void AnimateProperty(float time, float value){
        iTween.ValueTo( gameObject, iTween.Hash(
            "from", propertyValue,
            "to", value,
            "time", time,
            "delay", 1f,
            "onupdatetarget", gameObject,
            "onupdate", "UpdateMaterial",
            "easetype", iTween.EaseType.linear,
            "oncomplete","FadeOutComplete",
            "oncompletetarget" , this.gameObject
            )
        );
     
    }

    void UpdateMaterial(float newValue){
        propertyValue = newValue;
        mat.SetFloat("_Threshold", newValue);
    }

    void FadeOutComplete(){
        if(isFadeOut){
            ChangeLevel.Instance.OnFadeComplete();
        }
    }
}
