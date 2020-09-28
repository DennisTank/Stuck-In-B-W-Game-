using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TogBtn : MonoBehaviour
{
    ////////////
    RayDetect rayDetect;
    ////////////
    public LayerMask mask;
    private bool coroute;
    Animator anime;
    void Awake(){
        anime=GetComponent<Animator>();
        coroute=false;
        rayDetect=new RayDetect();
    }
    void Update() {
        if(detect()){
            StartCoroutine(stopAnime());
        }
        else{StopCoroutine(stopAnime());}
    }
    IEnumerator stopAnime(){
        if(!coroute){
            coroute=true;
            PlayerPrefs.SetInt("Toggle",(PlayerPrefs.GetInt("Toggle")==0)?1:0);
            anime.SetBool("toggle",true);
            yield return new WaitForSeconds(0.2f);
            anime.SetBool("toggle",false);
            coroute=false;        
        }
    }
    bool detect(){
        if(rayDetect.detect2D(transform.position,new Vector2(0,1),3,mask)
        &&rayDetect.collidedGo.GetComponent<PlutoScript>().smash){
            return true;
        }
        else{return false;}
    }
}
