using System.Collections;
using System.Collections.Generic;
using Script.Score;
using TMPro;
using UnityEngine;

public class ScoreInfo : MonoBehaviour
{
    public ScoreAttribute score;
    public TextMeshProUGUI scoreInfo;
    
    // Start is called before the first frame update
    void Start()
    {
        score = FindObjectOfType<ScoreAttribute>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreInfo.text = $"Score: {score.GetScore()}";
    }
}
