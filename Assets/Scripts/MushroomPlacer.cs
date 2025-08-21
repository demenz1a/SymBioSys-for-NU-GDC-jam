using UnityEngine;
using System.Collections.Generic;

public class MushroomPlacer : MonoBehaviour
{
    public GameObject mushroomPrefab;
    public Camera mainCamera;
    public LayerMask placementLayer;
    [SerializeField] private float mushroomOffsetY = 0.3f;
    [SerializeField] private int maxMushrooms = 3;
    [SerializeField] private float maxDistance = 3f; // Максимальная дистанция между грибами
    private Vector3 initialScale;

    private Queue<GameObject> placedMushrooms = new Queue<GameObject>();

    private void Awake()
    {
        initialScale = new Vector3(0.1991941f, 0.1936695f, 1f);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // ПКМ
        {
            Vector2 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero, Mathf.Infinity, placementLayer);

            if (hit.collider != null)
            {
                float surfaceAngle = hit.collider.transform.eulerAngles.z;
                surfaceAngle = Mathf.Repeat(surfaceAngle, 360f);

                bool isFloor = Mathf.Abs(surfaceAngle) < 0.1f || Mathf.Abs(surfaceAngle - 360f) < 0.1f;
                bool isCeiling = Mathf.Abs(surfaceAngle - 180f) < 0.1f;
                bool isWall = !isFloor && !isCeiling;

                float mushroomAngle = 0f;

                if (isFloor)
                    mushroomAngle = 0f;
                else if (isCeiling)
                    mushroomAngle = 180f;
                else if (isWall)
                    mushroomAngle = surfaceAngle;

                Quaternion rotation = Quaternion.Euler(0, 0, mushroomAngle);
                Vector3 offset = rotation * Vector3.up * mushroomOffsetY;
                Vector3 spawnPosition = (Vector3)hit.point + offset;

                // Проверка дистанции: хотя бы один гриб должен быть в пределах maxDistance
                if (placedMushrooms.Count > 0)
                {
                    bool withinRange = false;
                    foreach (var mushroom in placedMushrooms)
                    {
                        if (Vector3.Distance(mushroom.transform.position, spawnPosition) <= maxDistance)
                        {
                            withinRange = true;
                            break;
                        }
                    }

                    if (!withinRange)
                    {
                        Debug.Log("Грибы нельзя сажать слишком далеко друг от друга!");
                        return;
                    }
                }

                // Спавним гриб без родителя
                GameObject newMushroom = Instantiate(mushroomPrefab, spawnPosition, rotation);

                // Устанавливаем родителя (с сохранением мировых координат)
                newMushroom.transform.SetParent(hit.collider.transform, worldPositionStays: true);

                //newMushroom.transform.localScale = initialScale;


                // Продолжение
                placedMushrooms.Enqueue(newMushroom);
                //rat.SetMushroomTarget(newMushroom.transform);


                if (placedMushrooms.Count > maxMushrooms)
                {
                    GameObject oldest = placedMushrooms.Dequeue();
                    Destroy(oldest);
                }

                Debug.Log($"Surface Angle: {surfaceAngle}, Mushroom Angle: {mushroomAngle}");
            }
            else
            {
                Debug.Log("Здесь нельзя сажать гриб!");
            }
        }
    }
}


// Таймер скрытия сообщения
//if (messageText != null && messageText.enabled)
//{
//  messageTimer -= Time.deltaTime;
// if (messageTimer <= 0)
//{
//  messageText.enabled = false;
//}
//}
//}

//void ShowMessage(string message)
//{
//  if (messageText != null)
//{
//  messageText.text = message;
//messageText.enabled = true;
//messageTimer = messageDuration;
//}
//}
//}

