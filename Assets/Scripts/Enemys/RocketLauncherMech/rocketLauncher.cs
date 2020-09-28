using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocketLauncher : MonoBehaviour
{

    ////////
    Flip flip;
    ////////
    Animator anime;
    public GameObject rocket;
    public GameObject emmiter;
    public GameObject pluto;
    private bool coroute,die;
    private bool fr;

    void Awake() {
        anime=GetComponent<Animator>();
        coroute=false;
        fr=true;
        die=false;
        flip=new Flip(emmiter);
    }
  
    void Update()
    {
        if(GetComponent<Optimize>().inRaius){
            if(emmiter==null){die=true;}
            if(!die){
                StartCoroutine(Launcher());
            }else{           
                anime.SetBool("launch",false);
                StopCoroutine(Launcher());
            }
        }
        else{StopCoroutine(Launcher());}
    }

    IEnumerator Launcher(){
        if(!coroute){
            coroute=true;
            anime.SetBool("launch",true);
            yield return new WaitForSeconds(1);
            anime.SetBool("launch",false);
            if(emmiter!=null){Inst();}
            yield return new WaitForSeconds(5);
            if(emmiter!=null){fr=!fr;flip.flipNow(fr);}
            coroute=false;
        }
    }
    void Inst(){
        Instantiate(rocket,new Vector3(emmiter.transform.position.x
            ,emmiter.transform.position.y+0.25f
            ,emmiter.transform.position.z)
            ,(fr)?Quaternion.Euler(0,0,180):Quaternion.Euler(0,0,0));
    }
}
