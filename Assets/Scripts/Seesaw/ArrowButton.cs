using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowButton : MonoBehaviour
{
    public GameObject SeesawMinigame;
    public int direction = 0;
    void OnMouseDrag ()
    {
        SeesawMinigame.GetComponent<Seesaw>().RotateButtons(direction);
    }
}
