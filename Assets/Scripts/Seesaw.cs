using UnityEngine;

public class Seesaw : MonoBehaviour
{
    [SerializeField] GameObject pressurePlate, pusher;
    [SerializeField] float basePPlateY,basePushX;
    [SerializeField] float conversionMath;
    Vector3 pusherPos;
    private void Start()
    {
        if (pressurePlate != null)
        {
            basePPlateY = pressurePlate.transform.position.y;
        }
        if (pusher != null)
        {
            basePushX = pusher.transform.position.x;
        }
        conversionMath = basePushX - basePPlateY;
    }
    private void Update()
    {
        if (pressurePlate != null && pusher != null)
        {
            float xPos = pressurePlate.transform.position.y + conversionMath;
            float yPos = pusher.transform.position.y;
            float zPos = pusher.transform.position.z;
            pusherPos = new Vector3(xPos, yPos, zPos);
            pusher.transform.position = pusherPos;
        }
    }
}
