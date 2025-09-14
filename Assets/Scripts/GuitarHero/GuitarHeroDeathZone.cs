using UnityEngine;

public class GuitarHeroDeathZone : MonoBehaviour
{
    void OnTriggerEnter2D (Collider2D col)
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().Lose();
    }
}
