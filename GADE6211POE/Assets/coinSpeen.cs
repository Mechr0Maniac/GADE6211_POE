using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinSpeen : MonoBehaviour
{
    GameObject coin;
    // Start is called before the first frame update
    void Start()
    {
        coin = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        coin.transform.Rotate(0, 1, 0, Space.World);
    }
}
