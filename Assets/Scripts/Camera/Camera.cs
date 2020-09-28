using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    Animator anime;
    GameObject pluto;
    [HideInInspector] public bool shack;
    public float time;
    private float x,y;
    private int offSet;
    void Awake(){
       pluto=GameObject.FindGameObjectWithTag("Player");

        anime=GetComponent<Animator>();
        offSet = 10;
    }
    void Update()
    {
        if(shack){
            StartCoroutine(stopShack());
        }
    }
    void LateUpdate() {

        if(pluto.transform.position.x>transform.position.x+offSet){
            x=Mathf.Lerp(transform.position.x,pluto.transform.position.x-offSet,time);

        }else if(pluto.transform.position.x<transform.position.x-offSet){
            x=Mathf.Lerp(transform.position.x,pluto.transform.position.x+offSet,time);

        }
        if(pluto.transform.position.y>transform.position.y+offSet){
            y=Mathf.Lerp(transform.position.y,pluto.transform.position.y-offSet,time);
        }else if(pluto.transform.position.y<transform.position.y-offSet){
            y=Mathf.Lerp(transform.position.y,pluto.transform.position.y+offSet,time);
        }
        transform.position=new Vector3(x,y,0);

    }
    IEnumerator stopShack(){
        anime.SetBool("shack",true);
        yield return new WaitForSeconds(0.2f);
        anime.SetBool("shack",false);
        shack =false;
        StopCoroutine(stopShack());
    }
  
}
