using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thorny : MonoBehaviour
{
     //////////
    Flip flip;
    BasicMations motion;
    /////////
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
   }
   private void Update() {
       if(GetComponent<Optimize>().inRaius){
           StartCoroutine(routin());
           switch(sets){
               case 1:Right();break;
               case 2:Left();break;
           }
       }
       else{StopCoroutine(routin());}
   }
   IEnumerator routin(){
       if(!coroute){
           coroute=true;
           sets=0;
           anime.SetBool("run",false);
           yield return new WaitForSeconds(1);
           anime.SetBool("run",true);
           yield return new WaitForSeconds(0.5f);
           sets=1;
           yield return new WaitForSeconds(2);
           sets=0;
           anime.SetBool("run",false);
           yield return new WaitForSeconds(1);
           anime.SetBool("run",true);
           yield return new WaitForSeconds(0.5f);
           sets=2;
           yield return new WaitForSeconds(2);
           coroute=false;
       }
   }
   void Right(){
       flip.flipNow(true);
       motion.MoveRight(0.5f,speed);
   }
   void Left(){
       flip.flipNow(false);
       motion.MoveLeft(0.5f,speed);    
   }
}
