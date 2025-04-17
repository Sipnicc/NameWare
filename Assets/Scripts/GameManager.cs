using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    private int wins;
    [SerializeField]public float timer;
    private bool MinigameActive = false;
    private bool GameRunning = true;
    private GameObject Minigame;
    public List<GameObject> Minigames = new List<GameObject>();
    public TextMeshProUGUI timerText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameRunning)
        {
            return;
        }
        if(!MinigameActive)
        {
            timer = 6f;
            Minigame = Instantiate(Minigames[Random.Range(0, Minigames.Count)]);
            MinigameActive = true;
        }
        else
        {
            timer -= Time.deltaTime;
            timerText.text = "Time: " + timer.ToString("0.00");
        }
        if (timer <= -1)
        {
            MinigameActive = false;
            Destroy(Minigame);
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
        timer = 0;
        wins += 1;
    }

    IEnumerator LoadMenu(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene("Menu");
    }
}
