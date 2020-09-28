using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    public AudioClip coinA;
    public GameObject coinImg;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")){
            coinImg.SetActive(false);
            GetComponent<BoxCollider2D>().enabled=false;
            gameObject.AddComponent<AudioSource>().playOnAwake=false;
            GetComponent<AudioSource>().clip=coinA;
            GetComponent<AudioSource>().Play();
            PlayerPrefs.SetInt("coins",
            PlayerPrefs.GetInt("coins")+1
            );
            Destroy(gameObject,0.3f);
        }
    }

}
