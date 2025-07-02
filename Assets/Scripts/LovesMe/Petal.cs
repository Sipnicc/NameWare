using UnityEngine;

public class Petal : MonoBehaviour
{
    private LovesMe LovesMeScript;
    public Rigidbody2D rb2d;
    public SpriteRenderer Sprite;

    public float originRotationSpeed;

    private int minigamesPlayed;
    public int rotationSpeed;
    private bool FirstPull = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        minigamesPlayed = GameObject.Find("GameManager").GetComponent<GameManager>().minigamesPlayed;
        LovesMeScript = gameObject.transform.parent.parent.GetComponent<LovesMe>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb2d.gravityScale > 0)
        {
            transform.Rotate(0,0,rb2d.linearVelocity.y * rotationSpeed);
        }
        if (FirstPull && minigamesPlayed >= 50)
        {
            transform.parent.transform.Rotate(0,0, originRotationSpeed * Time.deltaTime);
        }
    }

    void OnMouseDrag()
    {
        if (FirstPull)
        {
            LovesMeScript.petals --;
            FirstPull = false;
        }
        transform.position = new Vector3 (transform.position.x, transform.position.y, 1); // Move the petal backwards so it doesn't interfere with the other petals.
        Sprite.sortingOrder = -100;
        rb2d.linearVelocity = new Vector2 (0,0);
        Vector3 ScreenMousePosition = Input.mousePosition;
        Vector3 WorldMousePosition = Camera.main.ScreenToWorldPoint(ScreenMousePosition);
        rb2d.gravityScale = 1;
        transform.position = new Vector3 (WorldMousePosition.x, WorldMousePosition.y, 1);
    }
}
