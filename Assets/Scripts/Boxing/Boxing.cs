using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boxing : MonoBehaviour
{
    public GameObject pointer;
    public float startPosition;
    public float endPosition;
    public float speed = 5f;
    public int direction = 1;
    public Animator playerAnimator;
    public Animator bagAnimator;
    public AudioSource audioSource;
    public AudioClip weakPunchSound;
    public AudioClip strongPunchSound;
    private int minigamesPlayed;
    private int maxDifficulty = 50;
    // Start is called before the first frame update
    void Start()
    {
        // Start the timer
        GameObject.Find("GameManager").GetComponent<GameManager>().timer = 5f;
        minigamesPlayed = GameObject.Find("GameManager").GetComponent<GameManager>().minigamesPlayed;
        maxDifficulty = GameObject.Find("GameManager").GetComponent<GameManager>().maxDifficulty;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("GameManager").GetComponent<GameManager>().gameRunning == false)
        {
            return;
        }
        pointer.transform.Translate(0,direction*speed*Time.deltaTime * Mathf.Clamp(Mathf.Sqrt(minigamesPlayed)/3, 1, maxDifficulty/3),0);
        if (Input.anyKeyDown)
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().timer = 0f;
            if (pointer.transform.position.y >= startPosition + 2.13f)
            {
                playerAnimator.SetBool("Win", true);
                bagAnimator.SetBool("Win", true);
                // Play the strong punch sound.
                audioSource.PlayOneShot(strongPunchSound);
                GameObject.Find("GameManager").GetComponent<GameManager>().Win();
            }
            else
            {
                playerAnimator.SetBool("Lose", true);
                // Play the weak punch sound.
                audioSource.PlayOneShot(weakPunchSound);
                GameObject.Find("GameManager").GetComponent<GameManager>().Lose();
            }
        }
        if (pointer.transform.position.y >= endPosition)
        {
            direction = -1;
        }
        else if (pointer.transform.position.y <= startPosition)
        {
            direction = 1;
        }
        if(GameObject.Find("GameManager").GetComponent<GameManager>().timer <= 0f)
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().Lose();
        }
    }
}
