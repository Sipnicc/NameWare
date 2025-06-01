using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowButtonSeesaw : MonoBehaviour
{
    public GameObject SeesawMinigame;
    public int direction = 0;
    void OnMouseDrag ()
    {
        SeesawMinigame.GetComponent<Seesaw>().RotateButtons(direction);
    }
}
