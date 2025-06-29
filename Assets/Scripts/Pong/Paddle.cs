using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public int speed;
    public Vector3 ScreenMousePosition;
    public Vector3 WorldMousePosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("GameManager").GetComponent<GameManager>().gameRunning == false)
        {
            return;
        }
        GetMousePosition();
        // Paddle Movement
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if(WorldMousePosition.x > 0)
            {
                transform.Translate(1 * speed * Time.deltaTime, 0, 0);
            }
            else
            {
                transform.Translate(-1 * speed * Time.deltaTime, 0, 0);
            }
        }
        else
        {
            if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(1 * speed * Time.deltaTime, 0, 0);
            }
            if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(-1 * speed * Time.deltaTime, 0, 0);
            }
        }
        transform.position = new Vector3 (Mathf.Clamp(transform.position.x, -3.9f, 3.9f), transform.position.y, transform.position.z);
    }

    void GetMousePosition()
    {
        ScreenMousePosition = Input.mousePosition;
        WorldMousePosition = Camera.main.ScreenToWorldPoint(ScreenMousePosition);
    }
}
