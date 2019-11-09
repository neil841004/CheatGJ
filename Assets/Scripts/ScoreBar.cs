using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBar : MonoBehaviour
{
    public float scoreA, scoreB;
    public GameObject wave;
    Vector3 position;
    Image scoreBar;
    // Start is called before the first frame update
    void Start()
    {
        scoreA = 10;
        scoreB = 10;
        scoreBar = this.GetComponent<Image>();
        position = wave.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        scoreBar.fillAmount = scoreA / (scoreB+scoreA);
        position.x = scoreBar.fillAmount *1170 + 335;
        wave.transform.position = position;
        if(scoreA<=0)scoreA = 0;
        if(scoreB<=0)scoreB = 0;
    }
}
