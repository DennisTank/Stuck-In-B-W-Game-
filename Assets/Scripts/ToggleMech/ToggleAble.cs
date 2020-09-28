using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleAble : MonoBehaviour
{
    SpriteRenderer sr;
    private int toggle;
    private Color before,after;
     void Awake() {
        sr=GetComponent<SpriteRenderer>();
        before=sr.color;
        after = (before==Color.white)?Color.black:Color.white;
        
    }
    void Update()
    {
        toggle=PlayerPrefs.GetInt("Toggle");
        sr.color=(toggle==0)?before:after;
        
    }
}
