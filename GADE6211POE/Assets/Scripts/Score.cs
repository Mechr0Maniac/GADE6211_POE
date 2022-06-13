using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{


    public int score;
    public static Score inst;


    public void IncScore()
    {

        score++;
        //scoreText.text = "SCORE" + score;
    }

    private void Awake()
    {
        inst = this;
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
