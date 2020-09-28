using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brike : MonoBehaviour
{
    private bool tpCrut;
    Rigidbody2D rb;
    BoxCollider2D bctd;
    Animator anime;
    private void Awake() {
        tpCrut=false;
        rb=GetComponent<Rigidbody2D>();
        bctd=GetComponent<BoxCollider2D>();
        anime=GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D other) {
       
        if(other.gameObject.CompareTag("Player")
        &&other.gameObject.GetComponent<PlutoScript>().smash){
            StartCoroutine(breakNow());
        }
        
    }
    IEnumerator breakNow(){
        if(!tpCrut){
            tpCrut=true;
            anime.SetBool("break",true);
            bctd.isTrigger=true;
            rb.bodyType=RigidbodyType2D.Dynamic;
            rb.gravityScale=10;
            rb.AddForce(new Vector2(0,50),ForceMode2D.Impulse);
            yield return new WaitForSecondsRealtime(1f);
            Destroy(gameObject);       
            tpCrut=false;
            StopCoroutine(breakNow());
        }
    }
}
