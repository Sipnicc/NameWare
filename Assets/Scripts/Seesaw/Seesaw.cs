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
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            return;
        }
        Platform.transform.Rotate(0, 0, Input.GetAxis("Horizontal") * -rotationSpeed * Time.fixedDeltaTime);
    }

    public void RotateButtons(int direction)
    {
        Platform.transform.Rotate(0, 0, direction * -rotationSpeed * Time.deltaTime);
    }
}
