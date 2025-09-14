using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuitarHeroManager : MonoBehaviour
{
    public GameObject NotePrefab;
    public float noteSpeed = 200;
    [SerializeField]public int notes = 3;
    public List<string> colorHexes = new List<string>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int minigamesPlayed = GameObject.Find("GameManager").GetComponent<GameManager>().minigamesPlayed;

        if (minigamesPlayed >= 50)
        {
            notes = 8;
            Time.timeScale = 1.5f;
        }
        else if (minigamesPlayed >= 40) notes = 7;
        else if (minigamesPlayed >= 30) notes = 6;
        else if (minigamesPlayed >= 20) notes = 5;
        else if (minigamesPlayed >= 10) notes = 4;

        for (int i = 0; i < notes; i++)
        {
            int position = Random.Range(-2,2);
            GameObject Note = Instantiate (NotePrefab, new Vector3(position * 1.95f, 5 + 2*i, 0), Quaternion.identity);
            Note.name = "Note";
            Note.transform.parent = transform;
            ColorUtility.TryParseHtmlString(colorHexes[position + 2], out Color newColor);
            Note.GetComponent<SpriteRenderer>().color = newColor;
            Note.GetComponent<Rigidbody2D>().AddForce(Vector3.down * noteSpeed);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
