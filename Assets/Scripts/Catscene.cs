using UnityEngine;

public class Catscene : MonoBehaviour
{
    public GameObject end;
    public void End()
    {
        Instantiate(end);
    }
}
