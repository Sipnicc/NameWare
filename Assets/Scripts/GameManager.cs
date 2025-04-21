using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    private int wins;
    [SerializeField]public float timer;
    private bool GameRunning = true;
    private GameObject Minigame;
    public List<GameObject> Minigames = new List<GameObject>();
    public TextMeshProUGUI timerText;
    // Start is called before the first frame update
    void Start()
    {
        Minigame = Instantiate(Minigames[Random.Range(0, Minigames.Count)]);
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameRunning)
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
        GameRunning = false;
        StartCoroutine ("LoadMenu", 1f);
    }
    public void Win()
    {
        wins += 1;
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
        Destroy(Minigame);
        Minigame = Instantiate(Minigames[Random.Range(0, Minigames.Count)]);
        timer = 0f;
    }
}
