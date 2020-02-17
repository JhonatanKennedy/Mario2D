using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour{

    public static SoundManager instance;

    public AudioSource JumpSfx;
    public AudioSource PowerUpSfx;
    public AudioSource PowerDownSfx;
    public AudioSource DeadSfx;
    public AudioSource coinSfx;
    public AudioSource itemAppear;
    public AudioSource deadFall;
    public AudioSource deathGoompa;
    public AudioSource finished;
    public AudioSource lifeUp;
    public AudioSource bgMusic;


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void JumpSound(AudioClip clip){
        JumpSfx.clip = clip;
        JumpSfx.Play();
    }
    public void PowerUpSound(AudioClip clip)
    {
        PowerUpSfx.clip = clip;
        PowerUpSfx.Play();
    }

    public void PowerDownSound(AudioClip clip)
    {
        PowerDownSfx.clip = clip;
        PowerDownSfx.Play();
    }

    public void DeadSound(AudioClip clip)
    {
        DeadSfx.clip = clip;
        DeadSfx.Play();
    }
    public void CoinSound(AudioClip clip)
    {
        coinSfx.clip = clip;
        coinSfx.Play();
    }
    public void ItemAppearSound(AudioClip clip)
    {
        itemAppear.clip = clip;
        itemAppear.Play();
    }

    public void DeadFallSound(AudioClip clip)
    {
        deadFall.clip = clip;
        deadFall.Play();
    }

    public void DeathGoompaSound(AudioClip clip)
    {
        deathGoompa.clip = clip;
        deathGoompa.Play();
    }

    public void FinishedSound(AudioClip clip)
    {
        finished.clip = clip;
        finished.Play();
    }

    public void LifeUpSound(AudioClip clip)
    {
        lifeUp.clip = clip;
        lifeUp.Play();
    }
    public void BgMusicSound(AudioClip clip)
    {
        bgMusic.clip = clip;
        bgMusic.Play();
    }
}
