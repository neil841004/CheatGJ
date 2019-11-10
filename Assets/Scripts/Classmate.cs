using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Classmate : MonoBehaviour
{
    public enum MateStatus
    {
        Gray, //一般狀態
        Yellow, //發光狀態
        Black, //扣分狀態
        Hand,
    }
    public MateStatus mateState;
    float seconds;
    int timeRamdon;
    public GameObject score;
    public GameObject desk, lightA;
    public Sprite deskY,deskB,deskG,deskP;
    public float scoreT = 0.6f;

    void Start()
    {
        timeRamdon = Random.Range(0,150);
        desk.GetComponent<SpriteRenderer>().sprite = deskG;
        
    }

    void Update()
    {
        if (GameManager.time == timeRamdon)
        {
            if (mateState == MateStatus.Gray)
            {
                ChangeState();
                GameManager.time++;
            }
        }
        if(GameObject.FindWithTag("Time").GetComponent<Timer>().timeCount <= 40 && GameObject.FindWithTag("Time").GetComponent<Timer>().timeCount > 20){
            scoreT = .8f;
        }
        if(GameObject.FindWithTag("Time").GetComponent<Timer>().timeCount <= 20){
            scoreT = 1.2f;
        }
    }
    void ChangeState()
    {
        int state = Random.Range(0, 4);
        switch (state)
        {
            case 0:
            case 1:
            case 2:
                StartCoroutine(YellowState());
                break;

            case 3:
                StartCoroutine(BlackState());
                break;
        }
        timeRamdon = Random.Range(0,150);
    }
  
    //加分狀態
    IEnumerator YellowState()
    {
        lightA.SetActive(true);
        yield return new WaitForSeconds(.7f);
        seconds = Random.Range(7f, 12f);
        mateState = MateStatus.Yellow;
        desk.GetComponent<SpriteRenderer>().sprite = deskY;
        this.GetComponent<BoxCollider2D>().enabled = true;
        yield return new WaitForSeconds(seconds);
        mateState = MateStatus.Gray;
        lightA.SetActive(false);
        desk.GetComponent<SpriteRenderer>().sprite = deskG;
        this.GetComponent<BoxCollider2D>().enabled = false;
    }

    //扣分狀態
    IEnumerator BlackState()
    {
        lightA.SetActive(true);
        yield return new WaitForSeconds(.7f);
        seconds = Random.Range(6f, 10f);
        mateState = MateStatus.Black;
        desk.GetComponent<SpriteRenderer>().sprite = deskB;
        this.GetComponent<BoxCollider2D>().enabled = true;
        yield return new WaitForSeconds(seconds);
        lightA.SetActive(false);
        desk.GetComponent<SpriteRenderer>().sprite = deskG;
        mateState = MateStatus.Gray;
        this.GetComponent<BoxCollider2D>().enabled = false;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("P1Ray")){
            if (mateState == MateStatus.Yellow)
            {
                score.GetComponent<ScoreBar>().scoreA +=scoreT;
            }if (mateState == MateStatus.Black)
            {
                score.GetComponent<ScoreBar>().scoreA -=scoreT*2.2f;
            }
        }
        if(other.CompareTag("P2Ray")){
            if (mateState == MateStatus.Yellow)
            {
                score.GetComponent<ScoreBar>().scoreB +=scoreT;
            }if (mateState == MateStatus.Black)
            {
                score.GetComponent<ScoreBar>().scoreB -=scoreT*2.2f;
            }
            
        }
    }
    
    
}
