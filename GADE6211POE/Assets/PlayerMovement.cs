using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    bool alive = true;

    public float speed=5 ;
    [SerializeField] Rigidbody rb;

    float horizontalInput;
    [SerializeField] float horizontalMulti = 2;

    private void FixedUpdate()
    { if (!alive) return;

        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;       
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMulti;
        rb.MovePosition(rb.position + forwardMove + horizontalMove);
    }
    void Update()
    {
        horizontalInput =Input.GetAxis("Horizontal");
    }
}
