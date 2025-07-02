using UnityEngine;

public class LovesMe : MonoBehaviour
{
    public GameObject PetalPrefab;
    public SpriteRenderer FaceSprite;
    public Sprite happySprite;
    public Sprite sadSprite;
    public Sprite superHappySprite;
    [SerializeField] public int petals = 7;

    private int maxDifficulty;
    private int minigamesPlayed;
    private int difficulty;

    private float startRotation;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startRotation = Random.Range (0f, 360f);
        //Set the difficulty.
        maxDifficulty = GameObject.Find("GameManager").GetComponent<GameManager>().maxDifficulty;
        minigamesPlayed = GameObject.Find("GameManager").GetComponent<GameManager>().minigamesPlayed;

        if (minigamesPlayed >= 40)
        {
            petals = 9;
        }
        else if (minigamesPlayed >= 30)
        {
            petals = 7;
        }
        else if (minigamesPlayed >= 20)
        {
            petals = 5;
        }
        else if (minigamesPlayed >= 10)
        {
            petals = 3;
        }
        else
        {
            petals = 1;
        }

        GameObject.Find("GameManager").GetComponent<GameManager>().timer = 5f;
        for (int i = 0; i < petals; i++)
        {
            GameObject Petal = Instantiate(PetalPrefab);
            Petal.transform.Rotate(0,0, startRotation + 360/petals * i);
            Petal.transform.parent = transform;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (petals <= 0)
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().Win();
        }
        if(GameObject.Find("GameManager").GetComponent<GameManager>().timer <= 0f)
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().Lose();
        }
        if(petals == 0)
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().Lose();
        }
    }
}
