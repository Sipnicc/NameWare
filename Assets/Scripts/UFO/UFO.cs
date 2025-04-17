using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO : MonoBehaviour
{
    public GameObject Overlay;
    public GameObject Flash;
    public GameObject Ship;
    public float speed = 5f;
    public float minWait = 1f;
    public float maxWait = 3f;
    private bool canMove = false;
    private bool minigameRunning = true;
    // Start is called before the first frame update
    void Start()
    {
        // The UFO is initially positioned off-screen to the left and below the visible area.
        // The UFO will move into the screen after a random wait time between minWait and maxWait seconds.
        Ship.transform.position = new Vector3(-7,-7,0);
        StartCoroutine(waitforstart(Random.Range(minWait, maxWait)));
    }

    // Update is called once per frame
    void Update()
    {
        // The player takes the picture.
        if (Input.GetKeyDown(KeyCode.Mouse0) && minigameRunning)
        {
            if (Ship.transform.position.x >= -5.6f && Ship.transform.position.x <= 5.6f)
            {
                GameObject.Find("GameManager").GetComponent<GameManager>().Win();
                print (Ship.transform.position.x);
            }
            else
            {
                GameObject.Find("GameManager").GetComponent<GameManager>().Lose();
            }
            // If the mouse is clicked and the minigame is running, stop the minigame and create a flash effect.
            minigameRunning = false;
            canMove = false;
            Overlay.SetActive(false);
            // Create a flash mouse is clicked.
            GameObject _Flash = Instantiate (Flash);
            _Flash.transform.parent = transform;
            transform.Rotate(0, 0, 15);
            transform.localScale = new Vector3 (0.8f, 0.8f, 0.8f);
            Ship.GetComponent<PolygonCollider2D>().enabled = true;
        }
        // The UFO starts moving after the wait time.
        if (canMove && minigameRunning)
        {
            Ship.transform.Translate(speed * Time.deltaTime, speed * Time.deltaTime, 0);
            if (Ship.transform.position.x >= 7f)
            {
                GameObject.Find("GameManager").GetComponent<GameManager>().Lose();
                minigameRunning = false;
                canMove = false;
            }
        }
    }

    IEnumerator waitforstart(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        canMove = true;
    }
}
