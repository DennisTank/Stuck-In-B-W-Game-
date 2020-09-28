using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirParticles : MonoBehaviour
{
    public float time;
   private void Start() {
       Invoke("die",time);
   }
   void die(){Destroy(gameObject);}
}
