using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficSpawner : MonoBehaviour
{
    public GameObject[] prefabs;
    public float randomTimeMin;
    public float randomTimeMax;
    public float objectSpeedMin;
    public float objectSpeedMax;
    public bool isOppositeDirection;

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
            /*if(fastestCar == null)
            {
                fastestCar = obj;
            }
            else if(fastestCar.GetComponent<Car>().speed < obj.GetComponent<Car>().speed)
            {
                fastestCar = obj;
            }*/
        }
        else
        {
            timeBtwSpawns -= Time.deltaTime;
        }
    }

    GameObject spawn()
    {
        int randItem = Random.Range(0, prefabs.Length);
        timeBtwSpawns = Random.Range(randomTimeMin, randomTimeMax);
        GameObject obj = prefabs[randItem];
        obj.GetComponent<Car>().speed = Random.Range(objectSpeedMin, objectSpeedMax);
        obj.GetComponent<Car>().FlipX = isOppositeDirection;
        Instantiate(obj, transform.position, Quaternion.identity);
        return obj;
    }
}
