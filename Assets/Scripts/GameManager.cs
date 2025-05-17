using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField]public int minigamesPlayed = 1;
    public int maxDifficulty = 50;
    [SerializeField]public float timer;
    [SerializeField]public bool gameRunning = true;
    private GameObject Minigame;
    public List<GameObject> Minigames = new List<GameObject>();
    public TextMeshProUGUI timerText;
    public GameObject Door;
    public GameObject BlackFade;

    public AudioSource audioSource;
    public AudioClip winClip;
    public AudioClip loseClip;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("LoadGame", 1f);
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
            timerText.text = timer.ToString("0");
        }
    }

    public void Lose()
    {
        if (!gameRunning)
        {
            return;
        }
        // Time is back to normal.
        Time.timeScale = 1;
        // Game over logic
        Debug.Log("Game Over");
        gameRunning = false;
        // Play the lose sound
        audioSource.PlayOneShot(loseClip);
        Instantiate(BlackFade);
        StartCoroutine ("LoadMenu", 4f);
    }
    public void Win()
    {
        if (!gameRunning)
        {
            return;
        }
        // Time is back to normal.
        Time.timeScale = 1;
        minigamesPlayed += 1;
        gameRunning = false;
        // Play the win sound!
        audioSource.PlayOneShot(winClip);
        StartCoroutine ("LoadGame", 1f);
    }

    IEnumerator LoadMenu(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene("Menu");
    }

    IEnumerator LoadGame(float seconds)
    {
        timerText.text = "0";
        yield return new WaitForSeconds(seconds);
        GameObject door = Instantiate(Door);
        GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>().text = minigamesPlayed.ToString();
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
