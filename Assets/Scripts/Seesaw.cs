using UnityEngine;

public class Seesaw : MonoBehaviour
{
    [SerializeField] GameObject pressurePlate, pusher;
    [SerializeField] float plateMoveDist = 0.1f;
    [SerializeField] float basePPlateY,basePushX, deltaX;
    [SerializeField] float conversionMath;
    Vector3 pusherPos;
    int moveNum = 0;
    private void Start()
    {
        if (pressurePlate != null)
        {
            Debug.Log("pplate");
            basePPlateY = pressurePlate.transform.position.y;
        }
        if (pusher != null)
        {
            Debug.Log("pusher");
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
    // private void Push(float dist)
    // {
    //     if (pressurePlate != null && pusher != null)
    //     {
    //         pressurePlate.transform.Translate(Vector3.down * dist);
    //         pusher.transform.Translate(Vector3.left * dist);
    //         moveNum++;
    //         Debug.Log("Push: moveNum = " + moveNum);
    //     }
    // }
    // private void OnCollisionEnter(Collision other)
    // {
    //     if (pressurePlate != null && pusher != null)
    //     {
    //         float xPos = pressurePlate.transform.position.y + conversionMath;
    //         float yPos = pusher.transform.position.y;
    //         float zPos = pusher.transform.position.z;
    //         pusherPos = new Vector3(xPos, yPos, zPos);
    //         pusher.transform.position = pusherPos;
    //     }
    //     if (other.gameObject.CompareTag("Rock") && moveNum < 8)
    //     {
    //         Push(plateMoveDist);
    //     }
    // }
}
