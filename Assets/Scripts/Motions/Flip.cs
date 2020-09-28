using UnityEngine;

public class Flip 
{
    private GameObject me;
    private Vector3 scale;
    public Flip(GameObject me){
        this.me=me;
        scale = me.transform.localScale;
    }
    public void flipNow(bool isfaceRight){
        if(isfaceRight){
            scale.x=Mathf.Abs(scale.x);
        }
        else{
            scale.x = -Mathf.Abs(scale.x);
        }
        me.transform.localScale=scale;
    }
}
