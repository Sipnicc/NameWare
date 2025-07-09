using UnityEngine;

public class BalloonSpike : MonoBehaviour
{
    public AudioSource audioPlayer;
    public AudioClip BoingSound;
    void OnCollisionEnter2D (Collision2D col)
    {
        if (col.gameObject.name == "Shield")
        {
            audioPlayer.PlayOneShot(BoingSound);
        }
    }
}
