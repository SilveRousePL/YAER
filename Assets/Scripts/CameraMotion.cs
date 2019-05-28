using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float current_x = GetComponent<Camera>().transform.position.x;
        float current_y = GetComponent<Camera>().transform.position.y;
        float current_z = GetComponent<Camera>().transform.position.z;

        GetComponent<Camera>().transform.position = new Vector3(current_x, GameObject.Find("Player").transform.position.y / 3, current_z);
    }
}
