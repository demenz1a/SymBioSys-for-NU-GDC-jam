using UnityEngine;
public class Laser : MonoBehaviour
{
    [SerializeField] Movement Movement;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Movement.RestartScene();
        }
    }
}