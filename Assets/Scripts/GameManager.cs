using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour{

    public static GameManager instance;

    public int coin;
    public int life;
    public int powerUp;
    public bool playerDiedRestart = false;
    
    public enum GameStatus {Playing,Defeat,Win,Dead}
    public GameStatus status;



    private void Awake(){
        if (instance == null){
            instance = this;
        }else{
            Destroy(gameObject);
            DontDestroyOnLoad(gameObject);
        }

    }

    void Start(){

    }

    void Update(){
        if(status == GameStatus.Playing){

        }else if(status == GameStatus.Win){
            StartCoroutine("wait");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            
        }else if(status == GameStatus.Defeat){

        }else{
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }

    }


    IEnumerator wait()
    {
        yield return new WaitForSeconds(2f);
    }
}
