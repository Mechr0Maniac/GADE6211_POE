using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinSpeen : MonoBehaviour
{
    GameObject coin;

public Transform playerTransform;
public float moveSpeed = 17f;

CoinMove coinMoveScript;
 

    // Start is called before the first frame update
    void Start()
    {
        coin = this.gameObject;

        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        coinMoveScript = gameObject.GetComponent<CoinMove>();
    }

   private void OnTriggerEnter(Collider other)
{
    if (other.gameObject.tag == "Coin Detector")
    {
       coinMoveScript.enabled = true; 
    }
}



}
