using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seesaw : MonoBehaviour
{
    public GameObject Platform;
    public float rotationSpeed = 50f;

    public Vector3 ScreenMousePosition;
    public Vector3 WorldMousePosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GetMousePosition();
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if(WorldMousePosition.x >0)
            {
                Platform.transform.Rotate(0, 0, 1 * -rotationSpeed * Time.fixedDeltaTime);
            }
            else
            {
                Platform.transform.Rotate(0, 0, -1 * -rotationSpeed * Time.fixedDeltaTime);
            }
        }
        else
        {
            Platform.transform.Rotate(0, 0, Input.GetAxis("Horizontal") * -rotationSpeed * Time.fixedDeltaTime);
        }
        print (WorldMousePosition.x);
    }

    public void RotateButtons(int direction)
    {
        Platform.transform.Rotate(0, 0, direction * -rotationSpeed * Time.deltaTime);
    }

    private void GetMousePosition ()
    {
        ScreenMousePosition = Input.mousePosition;
        WorldMousePosition = Camera.main.ScreenToWorldPoint(ScreenMousePosition);
    }
}
