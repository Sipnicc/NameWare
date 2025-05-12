using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clovers : MonoBehaviour
{
    public GameObject SadFace;
    public GameObject HappyFace;
    private List<GameObject> Faces = new List<GameObject>();

    // Start is called before the first frame update
    // Initializes the script by creating and positioning 10 clover GameObjects.
    // Each clover is instantiated from the SadFace prefab, positioned randomly
    // within a specified range, and scaled to a uniform size.
    void Start()
    {
        // Start the timer
        GameObject.Find("GameManager").GetComponent<GameManager>().timer = 5f;
        for (int i = 0; i < 25; i++)
            {
                GameObject sad = Instantiate(SadFace);
                sad.transform.position = new Vector3(Random.Range(-4f, 4f), Random.Range(-4f, 4f), 0);
                // Orientation is optimizable?
                sad.transform.localScale = new Vector3((0.5f*(Random.Range(0,2)*2-1)), 0.5f, 0.5f);
                sad.transform.parent = transform;
                // Add the instantiated face to the list of faces.
                Faces.Add(sad);
            }
        
        // Instantiate a happy face at a random position within the specified range.
        // The happy face is the one that the player will be looking for.
        GameObject happy = Instantiate(HappyFace);
        happy.transform.position = new Vector3(Random.Range(-4, 4), Random.Range(-4, 4), -1);
        happy.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        happy.transform.parent = transform;
        Faces.Add(happy);
        foreach (GameObject face in Faces)
        {
            face.GetComponent<Face>().Faces = Faces;
        }
        happy.GetComponent<Face>().Faces = Faces;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameObject.Find("GameManager").GetComponent<GameManager>().gameRunning)
        {
            return;
        }
        if (GameObject.Find("GameManager").GetComponent<GameManager>().timer <= 0f)
        {
            // You lose
            print("You lose!");
            GameObject.Find("GameManager").GetComponent<GameManager>().Lose();
        }
    }
}
