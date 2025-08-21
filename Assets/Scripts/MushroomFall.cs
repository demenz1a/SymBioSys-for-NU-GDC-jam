using UnityEngine;

public class MushroomFall : MonoBehaviour
{
    public float speed = 2f;
    public float resetY = 10f;
    public float bottomY = -10f;

    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);

        if (transform.position.y < bottomY)
        {
            Vector3 newPos = transform.position;
            newPos.y = resetY;
            transform.position = newPos;
        }
    }
}
