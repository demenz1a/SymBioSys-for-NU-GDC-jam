using UnityEngine;
using System.Collections;

public class Rat : MonoBehaviour
{
    public float moveSpeed = 3f;
    private Transform targetMushroom;
    private bool hasTarget = false;

    public bool chewedWire = false;
    private bool isWaiting = false;

    void Update()
    {
        if (!chewedWire && hasTarget && targetMushroom != null && !isWaiting)
        {
            MoveToTarget();
        }
    }

    private void MoveToTarget()
    {
        float distance = Vector2.Distance(transform.position, targetMushroom.position);

        if (distance > 0.05f)
        {
            Vector2 direction = (targetMushroom.position - transform.position).normalized;
            transform.Translate(new Vector2(direction.x, 0f) * moveSpeed * Time.deltaTime);
        }
        else
        {
            hasTarget = false;
        }
    }

    public void SetMushroomTarget(Transform mushroom)
    {
        targetMushroom = mushroom;
        hasTarget = true;
    }

    public void StopMovement()
    {
        hasTarget = false;
        targetMushroom = null;
        moveSpeed = 0f;
    }

    public void StartChewAndContinue(GameObject laserToDisable, GameObject zoneToDisable, Transform newTarget)
    {
        if (!isWaiting)
            StartCoroutine(ChewWireCoroutine(laserToDisable, zoneToDisable, newTarget));
    }

    private IEnumerator ChewWireCoroutine(GameObject laserToDisable, GameObject zoneToDisable, Transform newTarget)
    {
        isWaiting = true;
        moveSpeed = 0f;
        chewedWire = true;

        yield return new WaitForSeconds(2f);

        // Выключаем лазер и зону
        if (laserToDisable != null) laserToDisable.SetActive(false);
        if (zoneToDisable != null) zoneToDisable.SetActive(false);

        // Возвращаем движение
        chewedWire = false;
        isWaiting = false;
        moveSpeed = 3f;

        // Двигаемся к следующей цели
        if (newTarget != null)
        {
            SetMushroomTarget(newTarget);
        }
    }
}



