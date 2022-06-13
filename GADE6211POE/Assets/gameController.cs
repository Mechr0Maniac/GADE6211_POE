using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class gameController : MonoBehaviour
{
    public GameObject[] floors;
    public GameObject builder;
    public int tracker, z, rand;
    private double round;
    private float speed;
    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        z = 0;
        tracker = 42;
        for (int j = 1; j < 21; j++)
        {
            z = j * 2;
            Instantiate(floors[0], new Vector3(0, 0, z), Quaternion.identity);
        }
        builder.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, speed);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

    private void FixedUpdate()
    {
        if (builder.transform.position.z > tracker && builder.transform.position.z < tracker + 2)
        {
            z = tracker;
            rand = Random.Range(0, 10);
            round = Random.Range(1, 99) / 33 + 1;
            if (rand < 8)
                Instantiate(floors[0], new Vector3(0, 0, z), Quaternion.identity);
            else if (rand <= 9 && rand > 8)
                Instantiate(floors[System.Convert.ToInt32(System.Math.Ceiling(round))], new Vector3(0, 0, z), Quaternion.identity);
            else
                Instantiate(floors[System.Convert.ToInt32(System.Math.Ceiling(round+3))], new Vector3(0, 0, z), Quaternion.identity);
            rand = Random.Range(0, 100);
            tracker += 2;
        }
    }
}
