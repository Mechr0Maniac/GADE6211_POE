using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject coinPrefab;
    public GameObject pickup1Prefab;


    private void Start()
    {
        SpawnItem();
    }
    public void SpawnItem()
    { //Coin Spawn
        int coinsToSpawn = 10;

        for (int i = 0; i < coinsToSpawn; i++)
        {
          GameObject temp =   Instantiate(coinPrefab);
            temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());

        }

        //Pick-up spawn

        int pickup1Spawn = 1;

        for (int i = 0; i < pickup1Spawn; i++)
        {
            GameObject temp = Instantiate(pickup1Prefab);
            temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());

        }

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

        point.y = 1;
        return point;

    }
}
