using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    
    public GameObject[] obstaclePrefab;
    private float startDelay=2;
    private float repeatRate=2;
    private Vector3 spawnPos=new Vector3(25,0,0);
    private Playercontroller Playercontrollerscript;
    private int randomObstacle;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay,repeatRate);
    
        Playercontrollerscript=GameObject.Find("Player").GetComponent<Playercontroller>();
        
    }

    void SpawnObstacle(){
        if( Playercontrollerscript.gameover==false){
            randomObstacle =Random.Range (0,obstaclePrefab.Length);
            Instantiate(obstaclePrefab[randomObstacle],spawnPos,obstaclePrefab[randomObstacle].transform.rotation);

        }

    }

    // Update is called once per frame
    void Update()
    {

        
    }
}
