using System.Runtime.InteropServices;
using UnityEngine;

public class HighwayCar : MonoBehaviour {
    public float speed = 5f;
    private void Start() {
        
    }

    public void Update() {
        if (Input.GetAxis("Horizontal") != 0f)
        {
            Move((int)Input.GetAxis("Horizontal"));
        }
    }
    
    private void Move(int direction)
    {
        transform.Translate(0,direction*speed*Time.deltaTime,0);
    }
}