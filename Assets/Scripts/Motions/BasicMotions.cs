using UnityEngine;

public class BasicMations{

    private GameObject me;
    private float xDir;
    public BasicMations(GameObject me){
        this.me=me;
        xDir=0;
    }
    /// curveSet = 0.05f for normal and 0.005f for ice feel
    public void MoveRight(float curveSet,float speed){
        xDir=(xDir<1)?xDir+=curveSet:1;
        me.transform.Translate(xDir*speed*Time.deltaTime,0,0);
    }
    public void noMotion(float curveSet,float speed){
        if(xDir<0.1 && xDir> -0.1){xDir=0;}
        if(xDir>0){xDir-=curveSet;}
        else if (xDir<0){xDir+=curveSet;}
        me.transform.Translate(xDir*speed*Time.deltaTime,0,0);
    }
    public void MoveLeft(float curveSet,float speed){
        xDir=(xDir > -1)?xDir-=curveSet:-1;
        me.transform.Translate(xDir*speed*Time.deltaTime,0,0);
    }

    public void impactForce(float x,float y){
        me.GetComponent<Rigidbody2D>()
        .AddForce(new Vector2(x,y),ForceMode2D.Impulse);
    }
    public float xValue(){ return xDir;}
}