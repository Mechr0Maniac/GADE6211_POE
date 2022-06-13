using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject coinPrefab;
    public GameObject pickup1Prefab;
    public GameObject pickup2Prefab;
    public GameObject pickup3Prefab;


    private void Start()
    {
        //SpawnItem();
    }
    public void SpawnItem()
    {
        GameObject temp;
        int rand = Random.Range(0, 10);
        switch (rand)
        {
            //Pick-up spawn 1
            case 7: temp = Instantiate(pickup1Prefab); temp.transform.eulerAngles = new Vector3(0, 90, 0); break;
            //Pick-up spawn 2
            case 8: temp = Instantiate(pickup2Prefab); temp.transform.eulerAngles = new Vector3(0, 90, 0); break;
            //Pick-up spawn 3
            case 9: temp = Instantiate(pickup3Prefab); temp.transform.eulerAngles = new Vector3(0, 90, 0); break;
            //Coin Spawn
            default: temp = Instantiate(coinPrefab); temp.transform.eulerAngles = new Vector3(90, 0, 0); break;
        }
        temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
    }

    Vector3 GetRandomPointInCollider(Collider collider)
    {
        Vector3 point = new Vector3 (
            Random.Range(collider.bounds.min.x, collider.bounds.max.x),
            Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            Random.Range(collider.bounds.min.z, collider.bounds.max.z));

        if (point != collider.ClosestPoint(point))
        {
            point = GetRandomPointInCollider(collider);
        }

        point.y = 3;
        return point;
    }
}
