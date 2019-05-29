using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneySpawner : MonoBehaviour
{
    public GameObject prefab;
    public float randomTimeMin;
    public float randomTimeMax;
    public int moneyValue;

    private float timeBtwSpawns;

    // Start is called before the first frame update
    void Start()
    {
        timeBtwSpawns = Random.Range(randomTimeMin, randomTimeMax) + Random.Range(0, randomTimeMin);
    }

    // Update is called once per frame
    void Update()
    {
        if (timeBtwSpawns <= 0)
        {
            spawn();
        }
        else
        {
            timeBtwSpawns -= Time.deltaTime;
        }
    }

    GameObject spawn()
    {
        timeBtwSpawns = Random.Range(randomTimeMin, randomTimeMax);
        GameObject obj = prefab;
        obj.GetComponent<Money>().speed = 10;
        obj.GetComponent<Money>().value = moneyValue;
        Instantiate(obj, transform.position, Quaternion.identity);
        return obj;
    }
}