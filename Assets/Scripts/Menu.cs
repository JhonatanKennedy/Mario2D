using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour{
    public void startGame(){
        GameManager.instance.playerDiedRestart = false;
        SceneManager.LoadScene("stage1");
    }
}
