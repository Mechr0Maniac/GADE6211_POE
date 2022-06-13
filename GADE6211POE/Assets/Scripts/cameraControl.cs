using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControl : MonoBehaviour
{
    private float speed;

    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, speed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerExit(Collider obj)
    {
        Destroy(obj.gameObject);
    }
}
