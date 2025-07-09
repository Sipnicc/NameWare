using System.Runtime.InteropServices;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Balloon : MonoBehaviour
{
    public GameObject WarningSignPrefab;
    public GameObject SpikePrefab;

    public Transform ShieldAxis;
    private Vector3 WorldMousePosition;

    private float timer;
    public float spikeSpawnInterval;
    public float speed = 200f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("GameManager").GetComponent<GameManager>().gameRunning == false) return;
        timer += Time.deltaTime;
        if (timer >= spikeSpawnInterval)
        {
            int axis = Random.Range(0,2);
            // The spike will spawn either on the left or the right
            if (axis == 0)
            {
                float y = Random.Range(-4.5f, 4.5f);
                int x = (Random.Range(0,2)*2-1) * 6;
                StartCoroutine(SpawnSpike(x, y));
            }
            // The spike will spawn either up or down
            else if (axis == 1)
            {
                float x = Random.Range(-4.5f, 4.5f);
                int y = (Random.Range(0,2)*2-1) * 6;
                StartCoroutine(SpawnSpike(x, y));
            }
            timer = 0;
        }
        GetMousePosition();
        float AngleRad = Mathf.Atan2(WorldMousePosition.y - transform.position.y, WorldMousePosition.x - transform.position.x);
        float AngleDeg = (180 / Mathf.PI) * AngleRad;
        ShieldAxis.rotation = Quaternion.Euler(0, 0, AngleDeg);
    }

    void GetMousePosition()
    {
        Vector3 ScreenMousePosition = Input.mousePosition;
        WorldMousePosition = Camera.main.ScreenToWorldPoint(ScreenMousePosition);
    }

    IEnumerator SpawnSpike(float x, float y)
    {
        float signX;
        float signY;
        if (Mathf.Abs(x) == 6)
        {
            // The warning must appear on screen.
            signX = ((-6/x) * 2 + x);
            signY = y;
        }
        else
        {
            signY = (-6/y * 2 + y);
            signX = x;
        }
        GameObject sign = Instantiate(WarningSignPrefab, new Vector3(signX, signY, 0), Quaternion.identity);
        sign.transform.parent = transform;
        sign.transform.parent = gameObject.transform.parent;
        yield return new WaitForSeconds(0.5f);
        Destroy (sign, 0f);
        float AngleRad = Mathf.Atan2(transform.position.y - y, transform.position.x - x);
        float AngleDeg = (180 / Mathf.PI) * AngleRad;
        GameObject Spike = Instantiate(SpikePrefab, new Vector3(x, y, 0), Quaternion.Euler(0, 0, AngleDeg));
        Spike.GetComponent<Rigidbody2D>().AddForce(Spike.transform.TransformDirection (Vector3.right) * speed, ForceMode2D.Impulse);
        Spike.transform.parent = transform;

    }
}
