using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerController : MonoBehaviour
{
    private Vector3 jump, movie;
    private Rigidbody charControl;
    public Animator anim;
    private bool ghost, onGround;
    private int score;
    public Text scores, deathScreen;
    public float speed, jumpVal, grav, checkDist;
    private void Awake()
    {
        GameObject.Find("GameController").GetComponent<gameController>().Speed = speed;
        GameObject.Find("Main Camera").GetComponent<cameraControl>().Speed = speed;
    }
    // Start is called before the first frame update
    void Start()
    {
        charControl = gameObject.GetComponent<Rigidbody>();
        jump = new Vector3(0f, 5f, 0f);
        movie = new Vector3(0f, 0f, 1f);
        onGround = true;
        ghost = false;
        score = 0;
        deathScreen.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            charControl.AddForce(jump * jumpVal, ForceMode.Impulse);
            anim.Play("Jump");
        }
        if (Physics.Raycast(transform.position, Vector3.down, checkDist))
        {
            onGround = true;
        }
        else
        {
            onGround = false;
        }
        movie = new Vector3(Input.GetAxis("Horizontal"), 0f, 1f);
    }

    private void FixedUpdate()
    {
        charControl.AddForce(Physics.gravity * (grav - 1) * charControl.mass);
        charControl.MovePosition(transform.position + (movie * speed * Time.deltaTime));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.other.tag == "Obstacle")
        {
            if (!ghost)
                Destroy(gameObject);
            else
            { 
                Destroy(collision.gameObject);
                ghost = false; 
            }  
        }
        if(collision.other.tag == "Floor")
        {
            anim.Play("Run");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Obstacle")
        {
            score++;
            scores.text = "Score: " + score.ToString();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pickup")
        {
            ghost = true;
            Destroy(other.gameObject);
        }
    }

    private void OnDestroy()
    {
        scores.text = "";
        deathScreen.text = "You Died \n \n Score: " + score.ToString();
    }
}
