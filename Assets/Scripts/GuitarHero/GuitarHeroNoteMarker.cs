using UnityEngine;

public class GuitarHeroNoteMarker : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D col)
    {
        if (GameObject.Find("GameManager").GetComponent<GameManager>().gameRunning == false) return;
        if (col.gameObject.name == "Note")
        {
            transform.parent.GetComponent<GuitarHeroButton>().noteIn = true;
            print("note");
            transform.parent.GetComponent<GuitarHeroButton>().note = col.gameObject;
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (GameObject.Find("GameManager").GetComponent<GameManager>().gameRunning == false) return;
        if (col.gameObject.name == "Note") transform.parent.GetComponent<GuitarHeroButton>().noteIn = false;
    }
}
