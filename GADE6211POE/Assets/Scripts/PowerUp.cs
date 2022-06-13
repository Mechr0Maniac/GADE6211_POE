using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{

    public bool doublePoints;
    public float powerUpLength;

private PickUpManager thePickUpManager;


    // Start is called before the first frame update
    void Start()
    {
        thePickUpManager = FindObjectOfType<PickUpManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

void OnTriggerEnter(Collider other)
{
    if (other.gameObject.tag == "Player")
    {
thePickUpManager.ActivatePickUp(doublePoints, powerUpLength);
    }
    gameObject.SetActive(false);
}

}
