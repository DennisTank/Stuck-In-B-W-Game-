using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    // public string toFollowName; // name of gameobject before instentiation
    GameObject toFollow;
    float angle;
    float speed;
    float dTime;
    
    Vector3 target;
    bool follow;
    void Awake(){
        toFollow=GameObject.Find("Pluto"); // toFollowName can be ussed here
    }
    void Start(){
        speed=15;
        follow=false;
        Invoke("now",1);
    }
    void Update(){
        dTime=Time.deltaTime;
        //appling translation
        transform.Translate(-1*speed*dTime,0,0);
        //invoke afte a second;
        if(follow){nowFollow();}

    }
    void nowFollow(){
        // get targets magnitude
        target = toFollow.transform.position;
        target.x=target.x-transform.position.x;
        target.y=target.y-transform.position.y;
        target.z=0;
        // get the angle
        // angle = Mathf.Atan2(target.y,target.x)*Mathf.Rad2Deg;
        angle=Mathf.Atan2(target.y,target.x)*Mathf.Rad2Deg+180;
        //appling the angle
        transform.rotation=Quaternion.Euler(0,0
        ,angle);
    }
    void now(){follow=true;}

}
