using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private bool gameRunning = true;
    public Animator Anim;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb.AddForce(new Vector2(3*(Random.Range(0,2)*2-1), 0f), ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameRunning)
        {
            return;
        }
        if (transform.position.x > 2f || transform.position.x < -2f)
        {
            Anim.SetBool("Happy", false);
        }
        else
        {
            Anim.SetBool("Happy", true);
        }
        if (transform.position.y < -6f)
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().Lose();
        }
    }
}
