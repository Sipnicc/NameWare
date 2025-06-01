using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowButtonHighway : MonoBehaviour
{
    public int direction;
    public HighwayCar CarScript;
    void OnMouseDrag()
    {
        if (GameObject.Find("GameManager").GetComponent<GameManager>().gameRunning == false)
        {
            return;
        }
        CarScript.Move(direction);
    }
}
