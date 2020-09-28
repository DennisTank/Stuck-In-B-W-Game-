using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Manager : MonoBehaviour
{
   
    public GameObject UIScreen;
    public GameObject PauseMenu;
    // public GameObject DieMenu;
    
    public GameObject[] heart; 
    public Text coins; 
    [HideInInspector] public int heartValue; // prefrence
    [HideInInspector]public bool die,next;
    private int currentCoins;
    private void Awake() {
        UIScreen.SetActive(true);
        PauseMenu.SetActive(false);
    }
    void Start()
    {
        PlayerPrefs.SetInt("coins",0);// for test---
        heartValue=PlayerPrefs.GetInt("hvalue"); // for test---must be set by pref
        next=die=false;
        PlayerPrefs.SetInt("Toggle",0);
    }

    private void Update() {
        // hearts ince and dcre
        switch(heartValue){
            
            case 0:
                heart[0].SetActive(false);
                heart[1].SetActive(false);
                heart[2].SetActive(false);
                break;
            case 1:
                heart[0].SetActive(true);
                heart[1].SetActive(false);
                heart[2].SetActive(false);
                break;
            case 2:
                heart[0].SetActive(true);
                heart[1].SetActive(true);
                heart[2].SetActive(false);
                break;
            case 3:
                heart[0].SetActive(true);
                heart[1].SetActive(true);
                heart[2].SetActive(true);
                break;            
        }
        /// coins
        currentCoins=PlayerPrefs.GetInt("coins");
        if(currentCoins>=100){
            PlayerPrefs.SetInt("life",
                PlayerPrefs.GetInt("life")+1
            );
            PlayerPrefs.SetInt("coins",0);
        }
        coins.text=currentCoins.ToString();
    }

    public void PauseMenuOn(){
        UIScreen.SetActive(false);
        PauseMenu.SetActive(true);
        Time.timeScale=0;
    }
    public void PauseMenuOff(){
        UIScreen.SetActive(true);
        PauseMenu.SetActive(false);
        Time.timeScale=1;
    }
    public void DieMenuOn(){}
    public void DieMenuOff(){}
    public void AdMenuOn(){}//load ad scence
}
