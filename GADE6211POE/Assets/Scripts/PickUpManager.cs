using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpManager : MonoBehaviour
{

    private bool doublePoints;
    private bool active;

private float lengthCounter;
private Score theScoreManager;
private int normalPoints;


    // Start is called before the first frame update
    void Start()
    {
        theScoreManager = FindObjectOfType<Score>();

    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
lengthCounter-= Time.deltaTime;

if (doublePoints)
{
    theScoreManager.score = normalPoints * 2;
}

if (lengthCounter <= 0)
{
    theScoreManager.score = normalPoints;
    active = false;
}

        }
    }

    public void ActivatePickUp(bool points, float time )
    {
doublePoints = points;
lengthCounter = time;
normalPoints = theScoreManager.score;

active = true;
    }
}
