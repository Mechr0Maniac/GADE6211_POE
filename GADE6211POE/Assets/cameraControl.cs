using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 3);
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
