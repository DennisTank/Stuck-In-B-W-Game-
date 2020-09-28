using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiePrefabs : MonoBehaviour
{
    public GameObject dieBust;
    public int destroyTime; // 0-> infinity and others r secs
    private void Start() {
        if(destroyTime!=0){
        Invoke("desNow",destroyTime);    
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")){
            desNow();
        }     
    }
    void desNow(){
        Instantiate(dieBust,transform.position,transform.rotation);
        Destroy(gameObject);
    }   
}
