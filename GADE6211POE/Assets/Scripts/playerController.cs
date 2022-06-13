using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerController : MonoBehaviour
{
    private Vector3 jump, movie;
    private Rigidbody charControl;
    private bool ghost;
    private int score;
    public Text scores, deathScreen;
    // Start is called before the first frame update
    void Start()
    {
        charControl = gameObject.GetComponent<Rigidbody>();
        jump = new Vector3(0f, 5f, 0f);
        movie = new Vector3(0f, 0f, 1f);
        ghost = false;
        score = 0;
        deathScreen.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            charControl.AddForce(jump * 1.5f, ForceMode.Impulse);
        movie = new Vector3(Input.GetAxis("Horizontal"), 0f, 1f);
    }

    private void FixedUpdate()
    {
        charControl.MovePosition(transform.position + (movie * 3 * Time.deltaTime));
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
        if (collision.other.tag == "Pickup")
        {
            ghost = true;
            Destroy(collision.gameObject);
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

    private void OnDestroy()
    {
        scores.text = "";
        deathScreen.text = "You Died \n \n Score: " + score.ToString();
    }
}
