using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkWall : MonoBehaviour{

    public Goompa wallTest;
        
    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.CompareTag("Scenario") || collision.CompareTag("Enemy")){
            wallTest.checkWall = true;
        }
        
    }

}
