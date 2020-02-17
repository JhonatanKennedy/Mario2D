using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kill : MonoBehaviour{

    public Player Mario;
    public Goompa goompa;
    public BoxCollider2D killBox;
    public AudioClip powerDownSfx;
    public AudioClip DeadSfx;


    private void Start(){
        killBox = GetComponent<BoxCollider2D>();
    }



    private void FixedUpdate(){
        if(goompa.dead == true){
            killBox.size = new Vector2(0, 0);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.CompareTag("Player") && GameController.instance.getPowerUp() == 0){
            Mario.alive = false;
            GameController.instance.decrementLife();
            SoundManager.instance.DeadSound(DeadSfx);
        }
        else if(collision.CompareTag("Player") && GameController.instance.getPowerUp() == 1)
        {
            SoundManager.instance.PowerDownSound(powerDownSfx);
            GameController.instance.decrementPowerUp();
            Mario.invencible();
        }
        
    }
}
