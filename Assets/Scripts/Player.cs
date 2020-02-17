using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
    public bool alive = true;
    public GameObject bgMusic;

    public AudioClip JumpSfx;

    public float speed;
    public int jumpforce;
    private bool onGround;                                                           //variavel de controle do pulo
    public SpriteRenderer marioAnim;
                                   
    private Rigidbody2D Mario;                                                      //corpo
    private CapsuleCollider2D size;
    private Animator anim;                                                          //
    public LayerMask Layerground;                                                   //camada do chao
    public Transform groundChecker;                                                 //objeto que checa o chao
    private float groundCheckRadios = 0.2f;                                         //tamanho da "sombra do pulo"

    public bool facingRight = true;
    float move;

    void Start(){
        Mario = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        size = GetComponent<CapsuleCollider2D>();
        marioAnim = GetComponent<SpriteRenderer>();
        Physics2D.IgnoreLayerCollision(8, 9, false);
    }


    void Update(){
        if (alive){
            
            if (Input.GetKeyDown(KeyCode.Space) && onGround == true){                      //pula
                Mario.AddForce(Vector2.up * jumpforce);
                SoundManager.instance.JumpSound(JumpSfx);
            }

            if (GameController.instance.getPowerUp() == 0){
                playAnimations1();
                size.size = new Vector2(0.7393351f, 1.312282f);
            }else if (GameController.instance.getPowerUp() == 1)
            {
                playAnimations2();
                size.size = new Vector2(0.7393351f, 1.743862f);
            }
        }else{
            
            anim.Play("MiniMarioDeath");
            Physics2D.IgnoreLayerCollision(8, 9);
            bgMusic.SetActive(false);
        }
    }
    void FixedUpdate(){
        move = Input.GetAxis("Horizontal");                                             // a força do botao

        onGround = Physics2D.OverlapCircle(groundChecker.position, groundCheckRadios, Layerground);


        if (alive){
            if (Input.GetKey(KeyCode.LeftShift)){
                Mario.velocity = (new Vector2(move * speed * 1.3f, Mario.velocity.y));           // caso shift dobra a vel

            } else{
                Mario.velocity = new Vector2(move * speed, Mario.velocity.y);

            }
        }else{                                                                                    // ta morto
            Mario.velocity = new Vector2(0, 0);
        }
        

    }

    void playAnimations1(){

        if (!onGround){
            anim.Play("MiniMarioJump");

        }else if (move > 0){
            if (!facingRight){
                flip();
            }
            anim.Play("MiniMarioWalk");
        }else if (move < 0){
            if (facingRight){
                flip();
            }
            anim.Play("MiniMarioWalk");

        }else{
            anim.Play("MiniMarioIdle");
        }
    }

    void playAnimations2(){
        if (!onGround)
        {
            anim.Play("BigMarioJump");

        }
        else if (move > 0)
        {
            if (!facingRight)
            {
                flip();
            }
            anim.Play("BigMarioWalk");
        }
        else if (move < 0)
        {
            if (facingRight)
            {
                flip();
            }
            anim.Play("BigMarioWalk");

        }
        else
        {
            anim.Play("BigMarioIdle");
        }
    }

    void flip(){
        facingRight = !facingRight;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }

    public void invencible(){
        Physics2D.IgnoreLayerCollision(8,9);
        StartCoroutine(FlashingDamage());
    }
    
    IEnumerator FlashingDamage(){
        int i = 0;
        while (i < 5){
            marioAnim.enabled = true;
            yield return new WaitForSeconds(0.1f);
            marioAnim.enabled = false;
            yield return new WaitForSeconds(0.1f);
            i++;
        }
        marioAnim.enabled = true;
        Physics2D.IgnoreLayerCollision(8, 9, false);
    }

}
