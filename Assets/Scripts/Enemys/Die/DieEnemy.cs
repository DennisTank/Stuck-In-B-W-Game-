using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieEnemy : MonoBehaviour
{
    private bool tpCrut;
    public GameObject dieBust;
    private void Start() {
        tpCrut=false;
    }
    private void OnCollisionEnter2D(Collision2D other) {
       
        if(other.gameObject.CompareTag("Player")
        &&other.gameObject.GetComponent<PlutoScript>().smash){
            StartCoroutine(timePause());
        }
        
    }
    void desNow(){
        Instantiate(dieBust,transform.position,transform.rotation);
        Destroy(gameObject);
    }
       IEnumerator timePause(){
        if(!tpCrut){
            tpCrut=true;
            Time.timeScale=0.1f;
            yield return new WaitForSecondsRealtime(0.1f);
            Time.timeScale=1;
            desNow();
            tpCrut=false;
            StopCoroutine(timePause());
        }
    }
}
