using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlutoScript : MonoBehaviour
{   
    ////////
    Flip flip;
    BasicMations motion;
    RayDetect rayDetect;
    ////////////
    public LayerMask mask;
    public GameObject cam;
    public GameObject dust,jumpDust,smashDust,spark;
    [HideInInspector] public bool smash; 
    // not killable when smash and for fewsecs at healthMinus
    private float normalSpeed,mgSpeed,x;
    private bool tpCrut,spCrut,onGround,run,onIce,onMG;
    GameObject manager;
    Animator anime;
    Rigidbody2D rb;
    BtnControls btnControls;
    AudioSource audioSource;
    void Awake() {
        anime = GetComponent<Animator>();  
        rb=GetComponent<Rigidbody2D>(); 
        btnControls=GetComponent<BtnControls>();
        manager=GameObject.FindGameObjectWithTag("manager");
        audioSource=GetComponent<AudioSource>();
    }
    void Start()
    {    
        normalSpeed=25;
        mgSpeed=10;
        x=0;
        run=spCrut=tpCrut=false;
        flip=new Flip(gameObject);
        motion=new BasicMations(gameObject);
        rayDetect = new RayDetect();
    }


    void Update()
    {   
        x= motion.xValue();
        onGround=IsGround(3);
        Inputs();
        Animations();
    }

    void Inputs(){
        // movement
        if(Input.GetKey(KeyCode.A)){
        // if(btnControls.left){
            
            if(onMG){ motion.MoveLeft(0.5f,mgSpeed); }
            else if(onIce){ motion.MoveLeft(0.005f,normalSpeed); }
            else{ motion.MoveLeft(0.05f,normalSpeed); }
            
            flip.flipNow(false);
            run=true;

             if((x > -1f)&&onGround){ 
                Inst(dust);
             } 
        }
        else if(Input.GetKey(KeyCode.D)){
        // else if(btnControls.right){

            if(onMG){ motion.MoveRight(0.5f,mgSpeed); }
            else if(onIce){ motion.MoveRight(0.005f,normalSpeed); }
            else{ motion.MoveRight(0.05f,normalSpeed); }

            flip.flipNow(true);
            run=true;

            if((x < 1f)&&onGround){
                Inst(dust);
            } 
        }
        else{

            if(onMG){ motion.noMotion(0.5f,mgSpeed); }
            else if(onIce){ motion.noMotion(0.005f,normalSpeed); }
            else{ motion.noMotion(0.05f,normalSpeed); }

            run=false;
        } 
        // Jump 
        if(Input.GetKeyDown(KeyCode.Space)&&onGround){
        // if(btnControls.up&&onGround){
            btnControls.up=false;
            Inst(jumpDust); 
            motion.impactForce(0,50);
        }
        // Smash
        if(Input.GetKeyDown(KeyCode.S)&&!onGround){
        // if(btnControls.down&&!onGround){
            btnControls.down=false;
            Inst(spark);
            motion.impactForce(0,-50);
            smash=true;
        }
        else if (IsGround(2)){StartCoroutine(smashPause());}
        // Smash pause
        if(smash&&onGround){
            cam.GetComponent<Camera>().shack=true;
        }
    }
    void Animations(){
        // animations
        anime.SetBool("run",run);
        anime.SetBool("jump",!onGround);
        anime.SetBool("smash",smash);
    }
    bool IsGround(float y){
        if((rayDetect.detect2D(transform.position
        ,new Vector2(0,-1),y,mask)
        ||rayDetect.detect2D(transform.position
        ,new Vector2(0.5f,-1),y+1,mask)
        ||rayDetect.detect2D(transform.position
        ,new Vector2(-0.5f,-1),y+1,mask)))
        {
            if(rayDetect.collidedGo.CompareTag("moreG")){
                onMG = true;
                onIce=false;
            }
            else if(rayDetect.collidedGo.CompareTag("ice")){
                onMG = false;
                onIce=true;
            }
            else{
                onMG = false;
                onIce=false;
            }
            return true;
        }
        else{return false;}
        
    }
   void Inst(GameObject obj){
        Instantiate(obj
                ,new Vector3(transform.position.x
                ,transform.position.y-3,transform.position.z)
                ,transform.rotation);
   }
    IEnumerator smashPause(){
        if(smash&&!spCrut){
            spCrut=true;
            Inst(smashDust);
            yield return new WaitForSeconds(0.1f);
            smash=spCrut=false;
            StopCoroutine(smashPause());
        }
    }
    // only when die👇
    IEnumerator timePause(){
        if(!tpCrut){
            tpCrut=true;
            Time.timeScale=0.1f;
            yield return new WaitForSecondsRealtime(0.1f);
            Time.timeScale=1;
            manager.GetComponent<Manager>().die=true;
            tpCrut=false;
            StopCoroutine(timePause());
        }
    }
    IEnumerator healthMinus(){
        //if health < 0 -> die or👇
        if(manager.GetComponent<Manager>().heartValue==0){
            StartCoroutine(timePause());
        }
        else{
            anime.SetInteger("health",1);
            manager.GetComponent<Manager>().heartValue-=1;
            yield return new WaitForSeconds(1f);
            anime.SetInteger("health",0);
            StopCoroutine(healthMinus());
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("killable")&&!smash){
            if(rb.velocity.y==0){motion.impactForce(0,25);}          
            StartCoroutine(healthMinus());
        }
        else if (other.gameObject.CompareTag("unkillable")){
            if(rb.velocity.y==0){motion.impactForce(0,25);} 
            StartCoroutine(healthMinus());
        }
        if(other.gameObject.CompareTag("pable")){
            gameObject.transform.parent=other.gameObject.transform;
        }
        if(other.gameObject.CompareTag("below")){
                //die
        }
    }
    private void OnCollisionExit2D(Collision2D other) {
        if(other.gameObject.CompareTag("pable")){
            gameObject.transform.parent=null;
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("killable")&&!smash){
            if(rb.velocity.y==0){motion.impactForce(0,25);} 
            StartCoroutine(healthMinus());
        }
    }
    
}
