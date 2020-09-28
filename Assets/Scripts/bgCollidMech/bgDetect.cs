using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgDetect : MonoBehaviour
{
    ////////////
    RayDetect rayDetect;
    ////////////
    SpriteRenderer sr;
    BoxCollider2D box;
    public LayerMask mask;
    [HideInInspector]public bool isT;
    private Color myColor,bgColor;
    private int myMask;

    void Awake()
    {
        sr=GetComponent<SpriteRenderer>();
        box=GetComponent<BoxCollider2D>();
        myColor=sr.color;
        myMask=gameObject.layer;
        rayDetect = new RayDetect();
    }

    void Update() {
        isT=detect();
        box.isTrigger=isT;
        gameObject.layer=(isT)?0:myMask;
    }
    bool detect(){
        if(rayDetect.detect2D(transform.position,new Vector2(0,1),0.5f,mask)){
            bgColor=rayDetect.collidedGo.GetComponent<SpriteRenderer>().color;
            if(myColor.r==bgColor.r){return true;}
            else{return false;}
        }
        else{return false;}
    }
}
