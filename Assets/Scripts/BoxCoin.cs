using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoxCoin : MonoBehaviour{
    public Player Mario;
    public GameObject coin;
    public Animator anim;
    public AudioClip coinSfx;

    private bool active = true;

    void Start(){
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision){

        if (active && collision.CompareTag("Player")){
            SoundManager.instance.CoinSound(coinSfx);
            GameController.instance.incrementCoin();
            coin.SetActive(true);
            anim.Play("BoxStoped");
            active = false;
            StartCoroutine(waitFor());
        }
        
    }

    IEnumerator waitFor(){
        
        yield return new WaitForSeconds(0.17f);
        coin.SetActive(false);
    }

}
