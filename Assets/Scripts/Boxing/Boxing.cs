using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boxing : MonoBehaviour
{
    public GameObject pointer;
    public float startPosition;
    public float endPosition;
    public float speed = 0.5f;
    public int direction = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pointer.transform.Translate(0,direction*speed*Time.deltaTime,0);
        if (pointer.transform.position.y >= endPosition)
        {
            direction = -1;
        }
        else if (pointer.transform.position.y <= startPosition)
        {
            direction = 1;
        }
    }
}
