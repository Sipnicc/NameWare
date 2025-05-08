using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public AudioSource audioSource;
    public List<AudioClip> musicList = new List<AudioClip>();
    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = musicList[Random.Range(0, musicList.Count)];
        audioSource.Play();
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
    }
}
