using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBox : MonoBehaviour{
    private bool isActive = true;
    public GameObject mush;
    private Animator anim;

    public AudioClip itemAppear;


    void Start(){
        anim = GetComponent<Animator>();
    }


    private void OnTriggerEnter2D(Collider2D collision){
        if (isActive && collision.CompareTag("Player")){
            SoundManager.instance.ItemAppearSound(itemAppear);
            mush.SetActive(true);
            anim.Play("RedBoxAfter");
            isActive = false;
        }
    }
}
