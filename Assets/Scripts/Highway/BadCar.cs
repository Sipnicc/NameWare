using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadCar : MonoBehaviour
{
    [SerializeField] public float speed;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.name = "BadCar";
        speed = GameObject.Find("Car").GetComponent<HighwayCar>().speed * 1.2f; // Set the speed to be 20% faster than the player's car
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("GameManager").GetComponent<GameManager>().gameRunning == false)
        {
            return;
        }
        transform.position = new Vector3 (transform.position.x, transform.position.y - speed * Time.deltaTime, transform.position.z);
    }
}
