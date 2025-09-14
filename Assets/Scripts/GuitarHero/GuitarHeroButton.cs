using UnityEngine;

public class GuitarHeroButton : MonoBehaviour
{
    [SerializeField] public bool pressed;
    [SerializeField] public bool noteIn;

    [SerializeField] public GameObject note;
    public GuitarHeroManager MinigameManager;

    private AudioSource audioSource;
    public AudioClip noteClip;

    public string buttonNumber;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("GameManager").GetComponent<GameManager>().gameRunning == false) return;
        // print (noteIn);
        if (Input.GetKeyDown(buttonNumber))
        {
            if (!noteIn)
            {
                GameObject.Find("GameManager").GetComponent<GameManager>().Lose();
            }
            else
            {
                MinigameManager.notes -= 1;
                if (MinigameManager.notes <= 0) GameObject.Find("GameManager").GetComponent<GameManager>().Win();
                audioSource.PlayOneShot(noteClip);
                Destroy(note);
            }
        }
    }

    void OnMouseDown()
    {
        if (GameObject.Find("GameManager").GetComponent<GameManager>().gameRunning == false) return;
        print("Pressed");
        pressed = true;
        if (!noteIn)
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().Lose();
        }
        else
        {
            MinigameManager.notes -= 1;
            if (MinigameManager.notes <= 0) GameObject.Find("GameManager").GetComponent<GameManager>().Win();
            audioSource.PlayOneShot(noteClip);
            Destroy(note);
        }
    }
}
