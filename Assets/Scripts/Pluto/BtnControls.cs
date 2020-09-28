using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnControls : MonoBehaviour
{
    public GameObject button;
    private GameObject door,fade,doorin;
    [HideInInspector]public bool up,down,left,right;
    private bool press,nearDoor;
    private void Awake() {
        up=down=left=right=press=nearDoor=false;
        fade=GameObject.FindGameObjectWithTag("Finish");
        doorin=GameObject.FindGameObjectWithTag("doorin");
        doorin.GetComponent<Animator>().enabled=false;
        gameObject.GetComponent<PlutoScript>().enabled=false;
        Invoke("doorIn",1);
        Invoke("onControl",2);
    }
    private void Update() {
        button.SetActive(nearDoor);
    }
    public void UpT(){
        if(!press){
            press=up=true;
        }
    }
    public void DownT(){
         if(!press){
            press=down=true;
        }
    } 
    public void PressUp(){press=false;}
    public void LeftT(){left=true;}
    public void LeftF(){left=false;}
    public void RightT(){right=true;}
    public void RightF(){right=false;}

    public void Door(){
        transform.position= new Vector3(
            door.transform.position.x,
            transform.position.y,0
        );
        gameObject.GetComponent<PlutoScript>().enabled=false;
        door.GetComponent<Animator>()
        .SetBool("now",true);
        // wait for door animation + circular fadein
        Invoke("Fade",1);
        Invoke("nextLevel",2);
    }
    void Fade(){
        fade.GetComponent<Fade>().now=2;
    }
    void nextLevel(){
        // manager bool   
        GameObject.FindGameObjectWithTag("manager")
        .GetComponent<Manager>().next=true;  
    }
    void doorIn(){
        doorin.GetComponent<Animator>().enabled=true;

    }
    void onControl(){
        gameObject.GetComponent<PlutoScript>().enabled=true;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("door")){
            door=other.gameObject;
            nearDoor=true;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.CompareTag("door")){
            nearDoor=false;
        }
    }
}
