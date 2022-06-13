using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class gameController : MonoBehaviour
{
    public GameObject[] floors;
    public GameObject builder, boss;
    Vector3 bossMove;
    private GameObject bossPlay;
    public int tracker, z, rand, bossTimer;
    private double round;
    private bool bossActive;
    private float speed;
    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        bossActive = false;
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
            if (!bossActive)
            {
                switch (rand)
                {
                    default: Instantiate(floors[0], new Vector3(0, 0, z), Quaternion.identity); break;
                    case 7: Instantiate(floors[1], new Vector3(0, 0, z), Quaternion.identity); break;
                    case 8: Instantiate(floors[2], new Vector3(0, 0, z), Quaternion.identity); break;
                    case 9: Instantiate(floors[3], new Vector3(0, 0, z), Quaternion.identity); break;
                }
                rand = Random.Range(0, 100);
                if (rand > 90)
                {
                    GetComponent<ItemSpawner>().SpawnItem();
                }
            }
            else
                Instantiate(floors[0], new Vector3(0, 0, z), Quaternion.identity);
            tracker += 2;
        }
        bossTimer++;
        if (bossTimer >= 1000 && bossTimer < 10000)
        {
            bossTimer = 10000;
            StartCoroutine(Boss());
        }
        if(bossPlay != null)
            bossPlay.GetComponent<Rigidbody>().MovePosition(transform.position + (bossMove * speed * Time.deltaTime));
    }

    IEnumerator Boss()
    {
        int bossAttacks = Random.Range(1, 6);
        bossActive = true;
        bossMove = new Vector3(0, 0f, speed);
        bossPlay = Instantiate(boss, new Vector3(0, 6, z - 35), Quaternion.identity);
        if (bossPlay != null)
            bossPlay.GetComponent<Rigidbody>().MovePosition(bossPlay.transform.position + (bossMove * Time.deltaTime));
        for (int i = 0; i < bossAttacks; i++)
        {
            rand = Random.Range(0, 9);
            if (rand < 5)
            {
                yield return new WaitForSeconds(Random.Range(3, 7));
                bossPlay.GetComponent<Animator>().Play("LeftWind");
                yield return new WaitForSeconds(Random.Range(3, 7));
                bossPlay.GetComponent<Animator>().Play("LeftShoot");
            }
            else
            {
                yield return new WaitForSeconds(Random.Range(3, 7));
                bossPlay.GetComponent<Animator>().Play("RightWind");
                yield return new WaitForSeconds(Random.Range(3, 7));
                bossPlay.GetComponent<Animator>().Play("RightShoot");
            }
            yield return new WaitForSeconds(Random.Range(1, 4));
            bossPlay.GetComponent<Animator>().Play("Float");
        }
        Destroy(bossPlay);
        yield return new WaitForSeconds(5);
        bossTimer = 0;
        bossActive = false;
    }
}
