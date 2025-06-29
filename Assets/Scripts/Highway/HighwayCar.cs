using System.Runtime.InteropServices;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HighwayCar : MonoBehaviour
{
    public float speed = 5f;
    public float carSpawnInterval;
    private float carSpawnTimer = 0f;
    private int maxDifficulty;
    private int minigamesPlayed;
    private int direction;
    public Transform Road;
    public Vector3 ScreenMousePosition;
    public Vector3 WorldMousePosition;
    public GameObject BadCarPrefab;
    public GameObject WarningSignPrefab;
    private void Start()
    {
        maxDifficulty = GameObject.Find("GameManager").GetComponent<GameManager>().maxDifficulty;
        minigamesPlayed = GameObject.Find("GameManager").GetComponent<GameManager>().minigamesPlayed;
        Time.timeScale = Mathf.Clamp(Mathf.Sqrt(minigamesPlayed)/3, 1, maxDifficulty/10);
        // Start the timer
        GameObject.Find("GameManager").GetComponent<GameManager>().timer = 5f;
    }

    void Update()
    {
        if (GameObject.Find("GameManager").GetComponent<GameManager>().gameRunning == false)
        {
            return;
        }
        // Car movement
        GetMousePosition();
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (WorldMousePosition.x > 0)
            {
                transform.Translate(0, -1 * speed * Time.deltaTime, 0);
            }
            else
            {
                transform.Translate(0, 1 * speed * Time.deltaTime, 0);
            }
        }
        else
        {
            if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(0, -1 * speed * Time.deltaTime, 0);
            }
            if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(0, 1 * speed * Time.deltaTime, 0);
            }
        }
        transform.position = new Vector3 (Mathf.Clamp(transform.position.x, -4.42f, 4.42f), transform.position.y, transform.position.z);
        // Car spawner
        carSpawnTimer += Time.deltaTime;
        if (carSpawnTimer >= carSpawnInterval)
        {
            carSpawnTimer = 0f;
            // Spawn a new car at a random position on the road.
            StartCoroutine(SpawnCar(Random.Range(-4.3f, 4.3f)));
        }
        if (GameObject.Find("GameManager").GetComponent<GameManager>().timer <= 0f)
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().Win();
        }
    }

    IEnumerator SpawnCar(float xPosition)
    {
        GameObject sign = Instantiate(WarningSignPrefab, new Vector3(xPosition, 3f, 0), Quaternion.identity);
        sign.transform.parent = gameObject.transform.parent;
        yield return new WaitForSeconds(0.5f);
        Destroy(sign);
        // Instantiate a bad car at the specified x position.
        GameObject car = Instantiate(BadCarPrefab, new Vector3(xPosition, 6f, 0), Quaternion.identity);
        car.transform.parent = gameObject.transform.parent;
        car.transform.Rotate(0, 0, -90); // Rotate the car to face downwards.
    }
    
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "BadCar")
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().Lose();
        }
    }

    private void GetMousePosition ()
    {
        ScreenMousePosition = Input.mousePosition;
        WorldMousePosition = Camera.main.ScreenToWorldPoint(ScreenMousePosition);
    }
}
