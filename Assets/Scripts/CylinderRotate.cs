using Unity.VisualScripting;
using UnityEngine;

public class CylinderRotate : MonoBehaviour
{
    [SerializeField] bool isLocked = true;
    [SerializeField] Transform lockPanel;
    Vector3 rot, deltaRot;
    public void Unlock()
    {
        isLocked = false;
    }
    private void Start()
    {
        rot = gameObject.transform.localEulerAngles;
    }
    private void Update()
    {
        if (!isLocked)
        {
            deltaRot = gameObject.transform.localEulerAngles - rot;
            if (lockPanel !=null)
            {
                lockPanel.Rotate(deltaRot);
            }
            rot = gameObject.transform.localEulerAngles;            
        }
    }
}
