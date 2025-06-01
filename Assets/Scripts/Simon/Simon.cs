using System;
using System.Runtime.InteropServices;
using UnityEngine;

public class Simon : MonoBehaviour {

    public List<GameObject> Buttons;
    public float speed = 1f;
    private int minigamesPlayed;
    public AudioSource audioSource;
    public AudioClip buttonSound;
    void Start() {
        StartCoroutine(LightButtons());
        minigamesPlayed = GameObject.Find("GameManager").GetComponent<GameManager>().minigamesPlayed;
    }

    IEnumerator LightButtons() {
        yield return new WaitForSeconds(speed);
        for ( i = 0; i < MathF.Clamp((minigamesPlayed +1)/10, 2, 10) ; i++)
        {
            GameObject button = Buttons[Random.Range(0, Buttons.Count)];
            Color originalColor = button.GetComponent<SpriteRenderer>().material.color;
            button.GetComponent<SpriteRenderer>().material.color = Color.white;
            audioSource.PlayOneShot(buttonSound);
            yield return new WaitForSeconds(0.5f);
            button.GetComponent<SpriteRenderer>().material.color = originalColor;
        }
    }
}