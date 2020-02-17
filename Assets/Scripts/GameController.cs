using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour{

    public static GameController instance;
    Text textCoins;
    Text textLifes;
    public AudioClip lifeUp;

    int coin, life,powerUp;
    public bool nextMap= false;


    void Awake(){
        if (instance == null){
            instance = this;
        }
        textCoins = GameObject.Find("Coins").GetComponent<Text>();
        textLifes = GameObject.Find("Lifes").GetComponent<Text>();
        
    }


    public void incrementCoin()
    {
        coin++;
        if (coin == 100)
        {
            incrementLife();
            coin = 0;
            SoundManager.instance.LifeUpSound(lifeUp);
            GameManager.instance.life++;
        }
        textCoins.text = "X" + coin.ToString();
        textLifes.text = "X" + life.ToString();
    }

    public void incrementLife()
    {
        life++;
    }

    public void decrementLife(){
        life--;
        textLifes.text = "X" + life.ToString();
        if(life >= 0)
        {
            textLifes.text = "X" + life.ToString();

        }
        StartCoroutine("PlayerDied");
    }

    public void setPowerUp()
    {
        powerUp++;
    }

    public void decrementPowerUp()
    {
        powerUp--;
    }

    public int getPowerUp()
    {
        return powerUp;
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += levelFinishedLoading;

    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= levelFinishedLoading;
    }

    void levelFinishedLoading(Scene scene, LoadSceneMode mode){
        if(scene.name == "stage1"){ 
            if(!(GameManager.instance.playerDiedRestart)){
                coin = 99;
                life = 3;
                powerUp = 0;
            }else{
                coin = GameManager.instance.coin;
                life = GameManager.instance.life;
                powerUp = GameManager.instance.powerUp;
            }

            textCoins.text = "X" + coin.ToString();
            textLifes.text = "X" + life.ToString();
        }
    }


    IEnumerator PlayerDied(){
        yield return new WaitForSeconds(3f);

        if (life < 0){
            SceneManager.LoadScene("Menu");
        }else{
            GameManager.instance.playerDiedRestart = true;
            GameManager.instance.life = life;
            GameManager.instance.coin = 0;
            GameManager.instance.powerUp = 0;
            SceneManager.LoadScene("stage1");
        }

    }
}
