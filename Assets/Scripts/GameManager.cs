using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float score;
    private Playercontroller Playercontrollerscript;
    public Transform start;
    public float speed2;


    // Start is called before the first frame update
    void Start()
    {
        Playercontrollerscript=GameObject.Find("Player").GetComponent<Playercontroller>();
        score=0;
        Playercontrollerscript.gameover = true;
        StartCoroutine(PlayIntro());
    }

    // Update is called once per frame
    void Update()
    {
        if(!Playercontrollerscript.gameover)
        {
            if(Playercontrollerscript.doublespeed)
            {
                score += 2;
                }
            else
            {
                score++;
                }
        Debug.Log("Score: " + score);
        }

    }

    IEnumerator PlayIntro()
{
    Vector3 startPos = Playercontrollerscript.transform.position;
    Vector3 endPos = start.position;
    float journeyLength = Vector3.Distance(startPos, endPos);
    float startTime = Time.time;
    float distanceCovered = (Time.time - startTime) * speed2;
    float fractionOfJourney = distanceCovered / journeyLength;
    Playercontrollerscript.GetComponent<Animator>().SetFloat("Speed_Multiplier",0.5f);
    while (fractionOfJourney < 1)
    {
        distanceCovered = (Time.time - startTime) * speed2;
        fractionOfJourney = distanceCovered / journeyLength;
        Playercontrollerscript.transform.position = Vector3.Lerp(startPos, endPos,fractionOfJourney);
        yield return null;
    }
    Playercontrollerscript.GetComponent<Animator>().SetFloat("Speed_Multiplier",1.0f);
    Playercontrollerscript.gameover= false;
    }

}
