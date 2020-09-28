using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pushBtn : MonoBehaviour
{
    //////
    RayDetect rayDetect;
    //////
    public bool OnOff;
   public GameObject objTo;
   public string whatTo;
   public LayerMask mask;
   Animator anime;
   Behaviour bhvr;
   void Awake() {
       anime=GetComponent<Animator>();
       bhvr =(Behaviour)objTo.GetComponent(whatTo);
       rayDetect= new RayDetect(); 
       bhvr.enabled=false;
   }
   void Update() {
       if(OnOff){
            if(detect()){
                bhvr.enabled=true;
                anime.SetBool("push",true);             
            }
       }
       else{
            if(detect()){
                bhvr.enabled=true;
                anime.SetBool("push",true);
                
            }else{
                bhvr.enabled=false;
                anime.SetBool("push",false);
            }      
       }
   }
   bool detect(){
        return (rayDetect.detect2D(transform.position
        ,new Vector2(0,1),3,mask));
    }
}   
