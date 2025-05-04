using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cup : MonoBehaviour
{
    public Cups cupsScript; // Reference to the Cups script
    public GameObject Ball;
    public Animator animator; // Reference to the Animator component
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDrag()
    {
        print("Clicked!");
        if (!GameObject.Find("GameManager").GetComponent<GameManager>().gameRunning || cupsScript.changes < cupsScript.maxChanges)
        {
            // If the game is not running or the maximum number of changes has been reached, do nothing.
            return;
        }
        if (gameObject.name == cupsScript.CorrectCup.name)
        {
            //Win the game if the player clicks on the correct cup.
            Ball.transform.parent = transform.parent.parent;
            animator.SetBool("Up", true);
            GameObject.Find("GameManager").GetComponent<GameManager>().Win();
        }
        else
        {
            // Lose the game if the player clicks on the wrong cup.
            Ball.transform.parent = transform.parent.parent;
            animator.SetBool("Up", true);
            GameObject.Find("GameManager").GetComponent<GameManager>().Lose();
        }
    }
}
