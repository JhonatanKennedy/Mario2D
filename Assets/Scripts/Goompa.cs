using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goompa : MonoBehaviour{

    private Rigidbody2D goompa;
    private Animator anim;
    public float speed = 4f;
    public bool checkWall = false;
    public bool dead = false;
    public GameObject goompaPhysic;


    private bool isVisible = false;

    void Start(){
        goompa = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }


    void Update(){
        if (!dead){
            anim.Play("LiveGoompa");
        }
        else{
            anim.Play("DeadGoompa");
            speed = 0;
            Destroy(goompaPhysic, 0.25f);
        }
        
    }


    private void FixedUpdate(){
        if (isVisible){
            goompa.velocity = new Vector2(speed, goompa.velocity.y);
            if (checkWall){
                speed *= -1;
                checkWall = false;
            }
        }
        else{
            goompa.velocity = new Vector2(0f, goompa.velocity.y);
        }

    }

    private void OnBecameInvisible(){
        isVisible = false;
    }
    private void OnBecameVisible(){
        isVisible = true;
    }

}
