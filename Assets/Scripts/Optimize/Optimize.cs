using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Optimize : MonoBehaviour
{
   [HideInInspector]public bool inRaius;
   GameObject pluto;
   
   private void Awake() {
       pluto=GameObject.FindGameObjectWithTag("Player");
   } 
   private void Update() {
        if(Mathf.Abs(pluto.transform.position.x-transform.position.x)<50){
            inRaius=true;
        }    
        else{
            inRaius=false;
        }
   }
}
