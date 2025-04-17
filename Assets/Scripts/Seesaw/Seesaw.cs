using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seesaw : MonoBehaviour
{
    public GameObject Platform;
    public float rotationSpeed = 50f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Platform.transform.Rotate(0, 0, Input.GetAxis("Horizontal") * -rotationSpeed * Time.deltaTime);
    }
}
