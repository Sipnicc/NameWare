using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongBall : MonoBehaviour
{
    private float direction_y;
    private float direction_x;

    private int maxDifficulty;
    private int minigamesPlayed;
    public int speed = 3;

    public AudioSource audioSource;
    public List<AudioClip> bounceSounds = new List<AudioClip>();
    // Start is called before the first frame update
    void Start()
    {
        // Start the timer
        GameObject.Find("GameManager").GetComponent<GameManager>().timer = 5f;

        // Get the direction of the ball.
        direction_x = Random.Range(-0.8f, 0.8f);
        direction_y = Mathf.Sqrt(1 - direction_x * direction_x);

        maxDifficulty = GameObject.Find("GameManager").GetComponent<GameManager>().maxDifficulty;
        minigamesPlayed = GameObject.Find("GameManager").GetComponent<GameManager>().minigamesPlayed;

        // Set the speed.
        Time.timeScale = Mathf.Clamp(Mathf.Sqrt(minigamesPlayed)/3, 1, maxDifficulty/10);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3 (Mathf.Clamp(transform.position.x, -4.64f, 4.64f), Mathf.Clamp(transform.position.y, -4.64f, 4.64f), 0);
        if (GameObject.Find("GameManager").GetComponent<GameManager>().gameRunning == false)
        {
            return;
        }

        // Move the ball and bounce
        if (transform.position.y >= 4.64f)
        {
            direction_y = -direction_y;
            audioSource.PlayOneShot(bounceSounds[Random.Range(0,bounceSounds.Count)]);
        }
        if (transform.position.x <= -4.64f || transform.position.x >= 4.64f)
        {
            direction_x = -direction_x;
            audioSource.PlayOneShot(bounceSounds[Random.Range(0,bounceSounds.Count)]);
        }
        transform.Translate(direction_x * speed * Time.deltaTime,direction_y * speed * Time.deltaTime,0);
        //Lose if the ball falls.
        if(transform.position.y <= -4.64f)
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().Lose();
        }

        //Win if not.
        if(GameObject.Find("GameManager").GetComponent<GameManager>().timer <= 0f)
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().Win();
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Paddle")
        {
            direction_y = -direction_y;
            audioSource.PlayOneShot(bounceSounds[Random.Range(0,bounceSounds.Count)]);
        }
    }
}
