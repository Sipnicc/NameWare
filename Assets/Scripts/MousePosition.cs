using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePosition : MonoBehaviour
{
    public Vector3 ScreenMousePosition;
    public Vector3 WorldMousePosition;

    // Update is called once per frame
    void Update()
    {
        ScreenMousePosition = Input.mousePosition;
        WorldMousePosition = Camera.main.ScreenToWorldPoint(ScreenMousePosition);
        transform.position = new Vector3 (WorldMousePosition.x, WorldMousePosition.y, 0);
    }
}
