using UnityEngine;
using UnityEngine.Events;

public class DoorInteractable : SimpleHingeInteractable
{
    public UnityEvent OnOpen; 
    [SerializeField] Transform doorObject;
    [SerializeField] Vector3 rotationLimits;
    public bool isOpen;
    public bool isClosed;
    [SerializeField] Collider openCollider;
    [SerializeField] Collider closedCollider;
    private Vector3 startRotation;
    [SerializeField] Vector3 endRotation;
    private float startAngleX;
    protected override void Start()
    {
        base.Start();
        startRotation = transform.localEulerAngles;
        startAngleX = GetAngle(startRotation.x);
    }

    protected override void Update()
    {
        base.Update();
        if (doorObject != null)
        {
            doorObject.localEulerAngles = new Vector3(
                doorObject.localEulerAngles.x,
                transform.localEulerAngles.y,
                doorObject.localEulerAngles.z
            );
        }
        if (isSelected)
        {
            Debug.Log("Selected");
            CheckLimits();
        }
    }
    protected override void ResetHinge()
    {
        if (isClosed)
        {
            transform.localEulerAngles = startRotation;
        }
        else if(isOpen)
        {
            transform.localEulerAngles = endRotation;
            OnOpen.Invoke();
        }
        else
        {
            transform.localEulerAngles = new Vector3(
                startAngleX,
                transform.localEulerAngles.y,
                transform.localEulerAngles.z
            );            
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other == closedCollider)
        {
            Debug.Log("Closed");
            isClosed = true;
            ReleaseHinge();
        }
        else if(other == openCollider)
        {
            Debug.Log("Open");
            isOpen = true;
            ReleaseHinge();
        }
    }
    private void OnUnlocked()
    {
        UnlockHinge();
    }
    private void OnLocked()
    {
        LockHinge();
    }
    private void CheckLimits()
    {
        isClosed = false;
        isOpen = false;
        float localAngleX = GetAngle(transform.localEulerAngles.x);
        if (localAngleX >= startAngleX + rotationLimits.x || localAngleX <= startAngleX - rotationLimits.x)
        {
            Debug.Log("Check Limits Released: local: " + localAngleX + " start: " + startAngleX + " limit: " + rotationLimits.x);
            ReleaseHinge();
        }
    }
    private float GetAngle(float angle)
    {
        if (angle >= 180)
        {
            angle -= 360;
        }
        return angle;
    }
}
