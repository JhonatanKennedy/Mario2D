using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mush : MonoBehaviour{

    public Player Mario;
    public GameObject mush;
    public Rigidbody2D mushBody;

    public AudioClip powerUp;


    void Start(){
        mushBody = GetComponent<Rigidbody2D>();
    }

    void Update(){
        
    }

    private void FixedUpdate(){
        if (Mario.facingRight == true){
            mushBody.velocity = new Vector2(-4, mushBody.velocity.y);
        }
        else{
            mushBody.velocity = new Vector2(4, mushBody.velocity.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
         if(GameController.instance.getPowerUp() == 0 && collision.CompareTag("Player")){
            GameController.instance.setPowerUp();
            SoundManager.instance.PowerUpSound(powerUp);
            Destroy(mush);
         }else if(GameController.instance.getPowerUp() == 1 && collision.CompareTag("Player")){
            Destroy(mush);
         }
        
    }
}
