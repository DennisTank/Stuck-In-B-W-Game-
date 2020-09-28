using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class linear : MonoBehaviour
{
    public Vector2 direction;
    public float speed;
    void Update()
    {   float dTime=Time.deltaTime;
        transform.Translate(speed*direction.x*dTime,speed*direction.y*dTime,0);
    }
}
