using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    private int wins;
    [SerializeField]public float timer;
    [SerializeField]public bool gameRunning = true;
    private GameObject Minigame;
    public List<GameObject> Minigames = new List<GameObject>();
    public TextMeshProUGUI timerText;
    public GameObject Door;
    // Start is called before the first frame update
    void Start()
    {
        Minigame = Instantiate(Minigames[Random.Range(0, Minigames.Count)]);
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameRunning)
        {
            return;
        }
        else if (timer >= 0)
        {
            timer -= Time.deltaTime;
            timerText.text = "Time: " + timer.ToString("0.00");
        }
    }

    public void Lose()
    {
        // Game over logic
        Debug.Log("Game Over");
        gameRunning = false;
        StartCoroutine ("LoadMenu", 0.5f);
    }
    public void Win()
    {
        wins += 1;
        gameRunning = false;
        StartCoroutine ("LoadGame", 1f);
    }

    IEnumerator LoadMenu(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene("Menu");
    }

    IEnumerator LoadGame(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        GameObject door = Instantiate(Door);
        yield return new WaitForSeconds(0.5f);
        Destroy(Minigame);
        Minigame = Instantiate(Minigames[Random.Range(0, Minigames.Count)]);
        timer = 0f;
        print("Game Loaded!");
        yield return new WaitForSeconds(0.5f);
        Destroy(door);
        print("No more door!");
        gameRunning = true;
    }
}
