using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathGoompa : MonoBehaviour{

    public Goompa goompa;
    public AudioClip deadGoompa;

    private void OnTriggerEnter2D(Collider2D collision){
        goompa.dead = true;
        SoundManager.instance.DeathGoompaSound(deadGoompa);
    }


}
