using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu : MonoBehaviour
{
    public AudioSource audioSource;
    public List<AudioClip> musicList = new List<AudioClip>();
    public TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = musicList[Random.Range(0, musicList.Count)];
        audioSource.Play();
        scoreText.text = "Highest score: " + PlayerPrefs.GetInt("HighestScore").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Testing");
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            PlayerPrefs.SetInt("ButtonsInactive", PlayerPrefs.GetInt("ButtonsInactive") == 1 ? 0 : 1);
            print("Buttons Active: " + PlayerPrefs.GetInt("ButtonsInactive"));
        }
    }
}
