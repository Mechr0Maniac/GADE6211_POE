using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public float turnSpeed = 90;

    private void OnTriggerEnter(Collider other)
    {
        //if (other.gameObject.GetComponent<Ostacle>() != null)
        //{
        //    Destroy(gameObject);
        //    return;
        //}
        //Check if colliding with player
        if (other.gameObject.name != "Player")
        { return; }

     


        //Destroy item

        Destroy(gameObject);

    }




    void Start()
    {
        
    }

    
    void Update()
    {
        transform.Rotate(0, 0, turnSpeed * Time.deltaTime);
    }
}
