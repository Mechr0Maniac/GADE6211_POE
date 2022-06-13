using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMove : MonoBehaviour
{

    coinSpeen coinScript;
    private bool acitve;

    public bool Active
    {
        get { return acitve; }
        set { acitve = value; }
    }



    // Start is called before the first frame update
    void Start()
    {
        coinScript = gameObject.GetComponent<coinSpeen>();
    }

    // Update is called once per frame
    void Update()
    {
        if (acitve)
            StartCoroutine(Absorb());
    }

private void OnTriggerEnter(Collider other)

{
    if (other.gameObject.tag == "Player Bubble")
    {
        Destroy(gameObject);
    }
}
    IEnumerator Absorb()
    {
        transform.position = Vector3.MoveTowards(transform.position, coinScript.playerTransform.position,
            coinScript.moveSpeed * Time.deltaTime);
        yield return new WaitForSeconds(7);
        acitve = false;
    }

}
