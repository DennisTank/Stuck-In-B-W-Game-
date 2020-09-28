using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mmgm : MonoBehaviour
{
    public GameObject conti;

    private void Awake() {
        // PlayerPrefs.DeleteAll();
        if(PlayerPrefs.GetInt("conti")==0){
            conti.SetActive(false);
        }
        else{
            conti.SetActive(true);
        }
    }

    public void newGame(){
        PlayerPrefs.SetInt("conti",1);
        PlayerPrefs.SetInt("life",3);
        PlayerPrefs.SetInt("course",0);
        PlayerPrefs.SetInt("coins",0);
        PlayerPrefs.SetInt("hvalue",3);
        SceneManager.LoadScene("course0");
    }
    public void Quit(){
        PlayerPrefs.Save();
        Application.Quit();
    }
    public void Conti(){
        string level="course"+PlayerPrefs.GetInt("course").ToString();
        SceneManager.LoadScene(level);
    }
}
