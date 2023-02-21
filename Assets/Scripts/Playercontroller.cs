using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{
    private Rigidbody playerRb;
    public float jumpForce;
    public float gravityModifier;
    public bool isOnGround=true;
    public bool gameover=false;
    private Animator playerAnim;
    public ParticleSystem  explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource playerAudio;
    public bool doubleJump=false;
    public float doublejumpForce;
    public bool doublespeed=false;


    // Start is called before the first frame update
    void Start()
    {
        playerRb=GetComponent<Rigidbody>();
        Physics.gravity*=gravityModifier;
        playerAnim=GetComponent<Animator>();
        playerAudio=GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
       
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameover){
                playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isOnGround=false;
                playerAnim.SetTrigger("Jump_trig");
                dirtParticle.Stop();
                playerAudio.PlayOneShot(jumpSound,1.0f);
                doubleJump=false;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && !isOnGround && !doubleJump){
            doubleJump=true;
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerAnim.Play("Running_Jump",3,0f);
            playerAudio.PlayOneShot(jumpSound,1.0f);

        }

        if (Input.GetKey(KeyCode.LeftShift) ){
            doublespeed=true;
            playerAnim.SetFloat("Double_Speed",2.0f);
            Debug.Log("double speed");

        }
        else if(doublespeed){
            doublespeed=false;
            playerAnim.SetFloat("Double_Speed",1.0f);
        }
        
    }

    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.CompareTag("Ground")){
            isOnGround=true;
            dirtParticle.Play();
        }
        else if(collision.gameObject.CompareTag("Obstacle")){
            gameover=true;
            Debug.Log("Game Over!");
            playerAnim.SetBool("Death_b",true);
            playerAnim.SetInteger("DeathType_int",1);
            explosionParticle.Play();
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound,1.0f);
        }
    }
}
