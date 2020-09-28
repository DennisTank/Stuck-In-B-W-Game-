using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spiter : MonoBehaviour
{
    /////
    RayDetect rayDetect;
    /////
    private bool down,coroute;
    public GameObject emit;
    public GameObject spitBul;
    public LayerMask mask;
    Animator anime;
    void Awake() {
        anime=GetComponent<Animator>();
    }
    void Start(){
        coroute=false;
        rayDetect=new RayDetect();
    }
    void Update() {
        if(GetComponent<Optimize>().inRaius){
            detect();
            anime.SetBool("down",down);
            if(!down){
                StartCoroutine(spit());
            }
            else{
                StopCoroutine(spit());
                gameObject.GetComponent<spiter>().enabled=false;
            }
        }
        else{StopCoroutine(spit());}
    }
    IEnumerator spit(){
        if(!coroute){
            coroute=true;
            InstL();
            InstR();
            yield return new WaitForSeconds(2);
            coroute=false;
        }
    }
    void detect(){
        if(rayDetect.detect2D(transform.position,new Vector2(-0.3f,1),5.5f,mask)
        &&rayDetect.collidedGo.GetComponent<PlutoScript>().smash){
            down=true;
        }
        if(rayDetect.detect2D(transform.position,new Vector2(0.3f,1),5.5f,mask)
        &&rayDetect.collidedGo.GetComponent<PlutoScript>().smash){
            down=true;
        }
    }
    void InstL(){
        Instantiate(spitBul
        ,new Vector2(emit.transform.position.x-1
        ,emit.transform.position.y-0.35f)
        ,Quaternion.Euler(0,0,180));
    }
    void InstR(){
        Instantiate(spitBul
        ,new Vector2(emit.transform.position.x+1
        ,emit.transform.position.y-0.35f)
        ,Quaternion.Euler(0,0,0));
    }
}
