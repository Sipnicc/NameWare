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
    public Transform Road;
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
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            Move(1);
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            Move(-1);
        }

        // Move the road downwards.
        if (Road.transform.position.y <= -10f)
        {
            Road.transform.position = new Vector3(0, 0, 0);
        }
        else
        {
            Road.transform.position += new Vector3(0, -speed * Time.deltaTime, 0);
        }
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
    public void Move(int direction)
    {
        transform.Translate(0, -direction * speed * Time.deltaTime, 0);
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
}