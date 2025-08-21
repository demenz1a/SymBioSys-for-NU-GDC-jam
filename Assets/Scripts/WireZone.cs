using UnityEngine;

public class WireZone : MonoBehaviour
{
    public GameObject laser;
    public GameObject sparks;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Mushroom"))
        {
            laser.SetActive(false);
            sparks.SetActive(false);
        }
    }
}




