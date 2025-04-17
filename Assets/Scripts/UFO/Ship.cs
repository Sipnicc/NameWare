using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Frame")
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().Win();
        }
        else
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().Lose();
        }
    }
}
