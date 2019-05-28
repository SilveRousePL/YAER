using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficDestroyer : MonoBehaviour
{
    public float minX;
    public float maxX;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.x < minX || gameObject.transform.position.x > maxX)
        {
            //GetComponent<DetectFastestCar>().removeObject(gameObject);
            Destroy(gameObject);
        }
    }
}
