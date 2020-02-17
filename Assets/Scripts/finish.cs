using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finish : MonoBehaviour{

    public SpriteRenderer finish1;
    public GameObject finish2;
    public AudioClip finished;

    private void Awake()
    {
        finish1 = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision){
        SoundManager.instance.FinishedSound(finished);
        finish1.enabled = false;
        finish2.SetActive(true);
        StartCoroutine("waitL");
        
    }

    IEnumerator waitL(){
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("stage2");
    }
}
