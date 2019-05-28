using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectFastestCar : MonoBehaviour
{
    private List<GameObject> objects;
    private float fastestObjectSpeed;

    // Start is called before the first frame update
    void Start()
    {
        fastestObjectSpeed = 0;
        objects = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        fastestObjectSpeed = 0;
        foreach(GameObject o in objects)
        {
            if(o.GetComponent<Car>().speed > fastestObjectSpeed)
            {
                fastestObjectSpeed = o.GetComponent<Car>().speed;
            }
        }
    }

    public void addObject(GameObject o)
    {
        objects.Add(o);
    }

    public void removeObject(GameObject o)
    {
        objects.Remove(o);
    }

    public float getFastestSpeed()
    {
        return fastestObjectSpeed;
    }
}
