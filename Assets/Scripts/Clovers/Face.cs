using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Face : MonoBehaviour
{
    public bool isHappy = false;
    public List<GameObject> Faces = new List<GameObject>();
    private float direction_y = 1;
    private float direction_x = 1;
    public float speed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        direction_x = Random.Range(-5, 5);
        direction_y = Random.Range(-5, 5);
    }

    // Update is called once per frame
    void Update()
    {
        // Move and bounce the face around the screen.
        // If the face reaches the edge of the screen, it will bounce back in the opposite direction.
        if (transform.position.y <= -4 || transform.position.y >= 4)
        {
            direction_y = -direction_y;
        }
        if (transform.position.x <= -4 || transform.position.x >= 4)
        {
            direction_x = -direction_x;
        }
        transform.Translate(direction_x * speed * Time.deltaTime, direction_y * speed * Time.deltaTime, 0);
    }

    void OnMouseDrag()
    {
        Faces.Remove(gameObject);
        // Destroy all the faces but this one.
        foreach (GameObject Face in Faces)
        {
                Destroy(Face);
        }
        direction_x = 0;
        direction_y = 0;
        print("Clicked!");
        if (!isHappy)
        {
            // If the face is not happy, the player loses the game.
            GameObject.Find("GameManager").GetComponent<GameManager>().Lose();
        }
        else
        {
            // If the face is happy, the player wins the game.    
            GameObject.Find("GameManager").GetComponent<GameManager>().Win();
        }
    }
}
