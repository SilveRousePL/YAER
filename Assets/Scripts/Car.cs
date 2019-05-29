using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public float speed;
    public GameObject destroyEffect;

    public bool FlipX;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().flipX = FlipX;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //other.GetComponent<Player>().health--;
            //other.GetComponent<Player>().camAnim.SetTrigger("shake");
            //Instantiate(destroyEffect, transform.position, Quaternion.identity);
            //Destroy(gameObject);
            if (other.GetComponent<Player>().isInsensibility() == false)
            {
                //other.GetComponent<Player>().camAnim.SetTrigger("shake");
                other.GetComponent<Player>().decreaseLife();
            }
        }
    }
}
