using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowards : MonoBehaviour
{
    // Mode -> 0 for linear Motion No reverse
    // Mode -> 1 for reversiable linear Motion
    // Mode -> 2 for Loop
    public int Mode; 
   public GameObject[] point;
   private int currentIndex;
   private bool forward;
    void Start()
    {
        transform.position=point[0].transform.position;
        currentIndex=0;
        forward=true;
    }

    void Update()
    {   
        switch(Mode){
            case 0:noLoop();break;
            case 1:Reverse();break;
            case 2:Loop();break;
        }
    }
    void noLoop(){
        if(currentIndex<point.Length){
            transform.position= Vector3.MoveTowards(transform.position
            ,point[currentIndex].transform.position,15*Time.deltaTime);
            if(transform.position==point[currentIndex].transform.position){
                currentIndex++;
            }
        }
    }
    void Reverse(){
        if(forward&&(currentIndex==point.Length-1)){forward=false;}
        else if(currentIndex==0){forward=true;}

        transform.position= Vector3.MoveTowards(transform.position
            ,point[currentIndex].transform.position,15*Time.deltaTime);
        
        if(transform.position==point[currentIndex].transform.position){
            if(forward){
            currentIndex++;
            }else{
            currentIndex--;
            }
        }
    }
    void Loop(){
        if(currentIndex<point.Length){
            transform.position= Vector3.MoveTowards(transform.position
            ,point[currentIndex].transform.position,15*Time.deltaTime);
            if(transform.position==point[currentIndex].transform.position){
                if(currentIndex==point.Length-1){
                    currentIndex=0;
                }else{currentIndex++;}
            }
        }
    }
}
