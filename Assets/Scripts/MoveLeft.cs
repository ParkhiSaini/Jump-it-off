using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed=30;
    private Playercontroller Playercontrollerscript;
    private float leftBound =-15;



    // Start is called before the first frame update
    void Start()
    {
        Playercontrollerscript=GameObject.Find("Player").GetComponent<Playercontroller>();
        
    }

    // Update is called once per frame
    void Update()
    {
        // if(Playercontrollerscript.gameover==false){
        //     transform.Translate(Vector3.left *Time.deltaTime *speed);
        // }

        // if (transform.position.x<leftBouond && gameObject.CompareTag("Obstacle")){
        //     Destroy(gameObject);
        // }

        // if (Playercontrollerscript.doublespeed){
        //     transform.Translate(Vector3.left * Time.deltaTime * (speed*2));
        // }
        // else{
        //     transform.Translate(Vector3.left *Time.deltaTime * speed);
        // }
       
       if (Playercontrollerscript.gameover == false)
       {
        if (Playercontrollerscript.doublespeed)
        {
            transform.Translate(Vector3.left * Time.deltaTime * (speed * 2));
        }
        else
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
            }
        }
        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }


        
    }
}
