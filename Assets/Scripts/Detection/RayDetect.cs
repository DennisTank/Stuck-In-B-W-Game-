using UnityEngine;

public class RayDetect{

    public GameObject collidedGo;
    public bool detect2D(Vector2 myPos,Vector2 direction,float distance,LayerMask mask){
        RaycastHit2D hit2D=Physics2D.Raycast(myPos,direction,distance,mask);
        if(hit2D.collider!=null){
            collidedGo=hit2D.collider.gameObject;
            return true;
        }
        else{
            collidedGo=null;
            return false;
            }
    }
}