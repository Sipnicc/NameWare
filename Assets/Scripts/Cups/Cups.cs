using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cups : MonoBehaviour
{
    public int maxChanges = 5;
    [SerializeField] public int changes = 0;

    public float speed = 1f;
    private float startTimer = 0f;
    private float cup1Increment = 0f;
    private float cup2Increment = 0f;

    private bool pickedCups = false;
    private bool pickedBall = false;

    public List<GameObject> CupsList = new List<GameObject>();

    public GameObject Ball;
    [SerializeField] public GameObject CorrectCup;
    private GameObject cup1;
    private GameObject cup2;

    public AudioSource audioSource;
    public AudioClip cupSound;

    private Vector3 cup1Objective;
    private Vector3 cup2Objective;

    // Start is called before the first frame update
    void Start()
    {
        // Pick the correct cup randomly from the list of cups.
        CorrectCup = CupsList[Random.Range(0, CupsList.Count)];
        // Put the ball under the correct cup.
        Ball.transform.position = new Vector3 (CorrectCup.transform.position.x, Ball.transform.position.y, Ball.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (startTimer >= 1.5f)
        {   
            if(changes < maxChanges)
            {
                if (!pickedCups)
                {
                    // Pick the cups randomly from the list of cups.
                    PickCups();
                    // Play the sound.
                    if (cup1 != cup2)
                    {
                        audioSource.PlayOneShot(cupSound);
                    }
                }
                else if (cup1.transform.position == cup1Objective && cup2.transform.position == cup2Objective)
                {
                    pickedCups = false;
                    changes++;
                    if (changes >= maxChanges)
                    {
                        // Start the timer.
                        GameObject.Find("GameManager").GetComponent<GameManager>().timer = 5f;
                    }
                }
                else
                {
                    // Move the cups to their objectives.
                    cup1.transform.position = Vector3.MoveTowards(cup1.transform.position, cup1Objective, speed * Time.deltaTime);
                    cup2.transform.position = Vector3.MoveTowards(cup2.transform.position, cup2Objective, speed * Time.deltaTime);
                }
            }
            // Anchor the ball to the correct cup.
            if (!pickedBall)
            {
                // Set the ball as a child of the correct cup.
                Ball.transform.parent = CorrectCup.transform;
                pickedBall = true;
                print("Ball is under " + CorrectCup.name);
            }
        }
        else
        {
            startTimer += Time.deltaTime;
        } 

        //End the game if the timer reaches 0.
        if (GameObject.Find("GameManager").GetComponent<GameManager>().timer <= 0 && changes >= maxChanges)
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().Lose();
        }
    }

    private void PickCups()
    {
        cup1 = CupsList[Random.Range(0, CupsList.Count)];
        cup2 = CupsList[Random.Range(0, CupsList.Count)];
        // Swap the positions of the two cups.
        cup1Objective = cup2.transform.position;
        cup2Objective = cup1.transform.position;
        // Calculate the speed of the cups based on the distance between them.
        if (cup1.transform.position.x < cup2.transform.position.x)
        {
            cup1Increment = speed;
            cup2Increment = -speed;
        }
        else if (cup1.transform.position.x > cup2.transform.position.x)
        {
            cup1Increment = -speed;
            cup2Increment = speed;
        }
        print("Picked cups " + cup1.name + " and " + cup2.name);
        print("Cup 1 objective: " + cup1Objective + " Cup 2 objective: " + cup2Objective);
        pickedCups = true;
    }
}
