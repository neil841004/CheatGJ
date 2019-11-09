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
        scoreA = 30;
        scoreB = 30;
        scoreBar = this.GetComponent<Image>();
        position = wave.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        scoreBar.fillAmount = scoreA / (scoreB+scoreA);
        position.x = scoreBar.fillAmount;
        position.x *=1170;
        position.x +=335f;
        wave.transform.position = position;
    }
}
