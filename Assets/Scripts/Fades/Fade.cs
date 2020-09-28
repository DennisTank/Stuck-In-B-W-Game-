using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Fade : MonoBehaviour
{
    [HideInInspector]public int now;
    Image img;
    private void Awake() {
        img=GetComponent<Image>();
    }
    private void Start() {
        RandomColor();
        now=1;
    }
    private void Update() {
        GetComponent<Animator>().SetInteger("now",now);
    }
    void RandomColor(){
        int rm=Random.Range(0,5);
        if(rm<=2){img.color=Color.white;}
        else{img.color=Color.black;}
    }
}
