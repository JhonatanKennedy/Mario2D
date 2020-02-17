using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall : MonoBehaviour{

    public Player mario;
    public AudioClip DeathSfx;


    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.CompareTag("Player")){
            if (GameController.instance.getPowerUp() == 1)
            {
                GameController.instance.decrementPowerUp();
            }

            GameController.instance.decrementLife();
            SoundManager.instance.DeadFallSound(DeathSfx);
            mario.alive = false;
        }
    }
}
