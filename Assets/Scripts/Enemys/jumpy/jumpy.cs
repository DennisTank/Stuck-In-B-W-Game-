using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpy : MonoBehaviour
{
    //////////
    Flip flip;
    BasicMations motion;
    RayDetect rayDetect;
    /////////
    public LayerMask mask;
   Animator anime;
   private bool coroute;
   private float speed;
   private int sets;
   private void Awake() {
       coroute= false;
       speed = 10;
       anime=GetComponent<Animator>();
   }
   private void Start() {
       flip= new Flip(gameObject);
       motion= new BasicMations(gameObject);
       rayDetect =new RayDetect();
   }
   private void Update() {
       if(GetComponent<Optimize>().inRaius){
           StartCoroutine(routin());
           switch(sets){
               case 1:Right();break;
               case 2:Left();break;
           }
           anime.SetBool("jump",!onGround());
       }
       else{StopCoroutine(routin());}
   }
   IEnumerator routin(){
       if(!coroute){
           coroute=true;
           sets=0;
           yield return new WaitForSeconds(2);
           sets=1;
           yield return new WaitForSeconds(1);
           sets=0;
           yield return new WaitForSeconds(2);
           sets=2;
           yield return new WaitForSeconds(1);
           coroute=false;
       }
   }
   void Right(){
       flip.flipNow(true);
       motion.MoveRight(0.5f,speed);
       if(onGround()){motion.impactForce(0,10);}      
   }
   void Left(){
       flip.flipNow(false);
       motion.MoveLeft(0.5f,speed);
       if(onGround()){motion.impactForce(0,10);}      
   }
    bool onGround(){
        return rayDetect.detect2D(transform.position
        ,new Vector2(0,-1),3,mask);
    }
}
