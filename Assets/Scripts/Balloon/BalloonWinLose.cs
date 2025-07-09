using UnityEngine;

public class BalloonWinLose : MonoBehaviour
{
    public GameObject FlashPrefab;

    public AudioSource AudioSource;
    public AudioClip popAudio;

    public SpriteRenderer spriteRenderer;
    public Sprite SadSprite;
    public Sprite ScaredSprite;
    public Sprite HappySprite;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int minigamesPlayed = GameObject.Find("GameManager").GetComponent<GameManager>().minigamesPlayed;
        GameObject.Find("GameManager").GetComponent<GameManager>().timer = 5f;
        Time.timeScale = Mathf.Clamp(0.05f * minigamesPlayed, 1f, 2.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("GameManager").GetComponent<GameManager>().timer <= 0)
        {
            spriteRenderer.sprite = HappySprite;
            GameObject.Find("GameManager").GetComponent<GameManager>().Win();
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Hazard")
        {
            spriteRenderer.sprite = ScaredSprite;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Hazard")
        {
            spriteRenderer.sprite = SadSprite;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        GameObject flash = Instantiate(FlashPrefab);
        flash.transform.parent = transform.parent;
        GameObject.Find("GameManager").GetComponent<GameManager>().Lose();
        AudioSource.PlayOneShot(popAudio);
        Destroy(gameObject);
    }
}
